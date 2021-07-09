using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitchPointer : MonoBehaviour
{
    Master masterScript;
    float minVol;
    float volume;
    float pitch;
    float maxPitch;
    float minPitch;
    float angle;

    void Start()
    {
        masterScript=GetComponentInParent<Master>();
        minVol=masterScript.GetMinVol();
        maxPitch=masterScript.GetMaxPitch();
        minPitch=masterScript.GetMinPitch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol) {
            ChangeRotate();
        }
    }

    void ChangeRotate(){
        pitch=masterScript.GetPitch();
        if (pitch>maxPitch) pitch = maxPitch;
        if (pitch<minPitch) pitch = minPitch;
        angle = 1.5708f/(maxPitch-minPitch)*(pitch-minPitch);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0,0,angle*180/Mathf.PI));
    }
}
