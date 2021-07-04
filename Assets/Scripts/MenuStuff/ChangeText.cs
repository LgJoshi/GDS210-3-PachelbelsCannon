using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    TextMeshProUGUI myText;
    
    void Awake(){
        myText=GetComponent<TextMeshProUGUI>();
    }

    public void TextUpdate(string input){
        myText.text = input;
    }
}
