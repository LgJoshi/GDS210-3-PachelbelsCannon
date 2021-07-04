using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PitchDisplay : MonoBehaviour
{
    TextMeshProUGUI myText;
    bool active=true;
    Master masterScript;

    void Awake (){
        myText = GetComponent<TextMeshProUGUI>();
        masterScript = GetComponentInParent<Master>();
    }

    void Start(){
        StartCoroutine(ChangeText());
    }

    void FixedUpdate()
    {

    }

    IEnumerator ChangeText(){
        while (active){
            yield return new WaitForSeconds(0.25f);
            myText.text = masterScript.GetPitch().ToString();
        }
    }
}
