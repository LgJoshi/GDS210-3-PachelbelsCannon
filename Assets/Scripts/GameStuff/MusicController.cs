using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource;

    void OnEnable(){
        EventManager.GameStarted += Activate;
    }
    void OnDisable(){
        EventManager.GameStarted -= Activate;
    }

    void Awake(){
        audioSource=this.GetComponent<AudioSource>();
    }

    void Activate() {
        audioSource.Play();
    }
}
