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

    void Awake(){
        volData = new float[10];
        pitchData = new float[10];
    }

    public float maxVol;
    public float minVol;
    public float maxPitch;
    public float minPitch;

    public float GetMaxVol(){
        return maxVol;
    }
    public float GetMinVol(){
        return minVol;
    }
    public float GetMaxPitch(){
        return maxPitch;
    }
    public float GetMinPitch(){
        return minPitch;
    }

    public void SetMaxVolume(string num){
        maxVol=float.Parse(num);
    }
    public void SetMinVolume(string num){
        minVol=float.Parse(num);
    }
    public void SetMaxPitch(string num){
        maxPitch=float.Parse(num);
    }
    public void SetMinPitch(string num){
        minPitch=float.Parse(num);
    }


    public float volume;
    public float pitch;

    public float GetVolume(){
        return volume;
    }
    public float GetPitch(){
        return pitch;
    }

    public void SetVolume(float num){
        volNum+=1;
        if (volNum==volData.Length) volNum=0;
        totalVol-=volData[volNum];
        volData[volNum]=num;
        totalVol+=volData[volNum];
        volume=totalVol/volData.Length;
        if (volume>maxVol) volume=maxVol;
        if (volume<minVol) volume=minVol;
    }
    public void SetPitch(float num){
        pitchNum+=1;
        if (pitchNum==pitchData.Length) pitchNum=0;
        totalPitch-=pitchData[pitchNum];
        pitchData[pitchNum]=num;
        totalPitch+=pitchData[pitchNum];
        pitch=totalPitch/pitchData.Length;
        if (pitch>maxPitch) pitch=maxPitch;
        if (pitch<minPitch) pitch=minPitch;
    }
}
