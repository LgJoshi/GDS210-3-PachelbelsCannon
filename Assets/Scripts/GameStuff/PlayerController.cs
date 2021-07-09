using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Master masterScript;
    Animator anim;

    float volume;

    float minVol;

    void Start(){
        masterScript=GetComponentInParent<Master>();
        anim=this.GetComponent<Animator>();
        minVol=masterScript.GetMinVol();
    }

    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol) {
            anim.SetBool("triggered", true);
        } else {
            anim.SetBool("triggered", false);
        }
    }
}
