using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicListener : MonoBehaviour
{
    AudioClip micInput;
    Master masterScript;

    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    [SerializeField] float something;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    // Start is called before the first frame update
    void Awake()
    {
        masterScript = GetComponentInParent<Master>();

        if (Microphone.devices.Length>0){
            micInput = Microphone.Start(Microphone.devices[2],true,999,AudioSettings.outputSampleRate);
            //microphoneInitialized = true;
            Debug.Log("Name: " + Microphone.devices[2]);
        }
        GetComponent<AudioSource>().clip = micInput;
        GetComponent<AudioSource>().Play();

        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
    }

    void Start(){
        /*foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            Debug.Log(Microphone.devices.Length);
        }*/
    }

    void FixedUpdate()
    {
        AnalyzeSound();
        masterScript.SetVolume(DbValue);
        masterScript.SetPitch(PitchValue);
    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
        if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
        // get sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        {
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
            continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples; // convert index to frequency
    }
}
