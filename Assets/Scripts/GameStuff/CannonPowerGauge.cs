using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonPowerGauge : MonoBehaviour
{
    Master masterScript;
    float minVol;
    float maxVol;
    float volume;
    Slider slide;

    void Start()
    {
        slide = GetComponent<Slider>();
        masterScript=GetComponentInParent<Master>();
        minVol=masterScript.GetMinVol();
        maxVol=masterScript.GetMaxVol();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol) {
            ChangeFill();
        }
    }

    void ChangeFill(){
        slide.value = (volume-minVol)/(maxVol-minVol);
    }
}
