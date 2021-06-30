using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    public float volume;
    public float pitch;

    public float GetVolume(){
        return volume;
    }

    public float GetPitch(){
        return pitch;
    }

    public void SetVolume(float num){
        volume=num;
    }

    public void SetPitch(float num){
        pitch=num;
    }

}
