using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonCooldownGauge : MonoBehaviour
{
    Master masterScript;
    float minVol;
    float volume;
    bool active=false;
    bool cooling=false;
    bool done=true;
    Slider slide;
    [SerializeField] float shootCooldown;
    [SerializeField] float initDelay;

    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = 0;
        masterScript=GetComponentInParent<Master>();
        minVol=masterScript.GetMinVol();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol && done && !active) {
            active=true;
            done=false;
        }

        if (active){
            slide.value += Time.deltaTime/initDelay;
            if (slide.value >= 1f) {
                slide.value = 1f;
                active=false;
            }
        }

        if(cooling){
            slide.value -= Time.deltaTime/(shootCooldown-initDelay);
            if (slide.value <= 0f) {
                slide.value = 0f;
                cooling=false;
                done=true;
            }
        }
    }

    public void Fired(){
        active=true;
        done=false;
    }

    public void Cooled(){
        cooling=true;
    }
}
