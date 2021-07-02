using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    [SerializeField] int volNum=0;
    float totalVol;
    [SerializeField] int pitchNum=0;
    float totalPitch;

    [SerializeField] float[] volData;
    [SerializeField] float[] pitchData;

    public float volume;
    public float pitch;

    public float GetVolume(){
        return volume;
    }

    public float GetPitch(){
        return pitch;
    }

    void Awake(){
        volData = new float[10];
        pitchData = new float[10];
    }

    public void SetVolume(float num){
        volNum+=1;
        if (volNum==volData.Length) volNum=0;
        totalVol-=volData[volNum];
        volData[volNum]=num;
        totalVol+=volData[volNum];
        volume=totalVol/volData.Length;
    }

    public void SetPitch(float num){
        pitchNum+=1;
        if (pitchNum==pitchData.Length) pitchNum=0;
        totalPitch-=pitchData[pitchNum];
        pitchData[pitchNum]=num;
        totalPitch+=pitchData[pitchNum];
        pitch=totalPitch/pitchData.Length;
    }

}
