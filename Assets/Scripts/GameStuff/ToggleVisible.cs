using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisible : MonoBehaviour
{

    void OnEnable(){
        EventManager.GameWon += ToggleEnable;
    }
    void OnDisable(){
        EventManager.GameWon -= ToggleEnable;
    }

    void ToggleEnable(){
        this.transform.localPosition = new Vector3(179,15,0);
    }
}
