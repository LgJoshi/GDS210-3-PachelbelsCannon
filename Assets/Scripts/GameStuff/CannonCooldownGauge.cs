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
    Slider slide;
    [SerializeField] float shootCooldown;

    void Start()
    {
        slide = GetComponent<Slider>();
        masterScript=GetComponentInParent<Master>();
        minVol=masterScript.GetMinVol();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol) {
            active=true;
        }

        if (active){
            slide.value -= Time.deltaTime/shootCooldown;
            if (slide.value <= 0) {
                slide.value = 1f;
                active=false;
                Debug.Log("reload cd gauge");
            }
        }
    }
}
