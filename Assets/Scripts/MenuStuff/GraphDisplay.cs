using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphDisplay : MonoBehaviour
{
    [SerializeField] Sprite circleSprite;
    GameObject dot;
    RectTransform dotRect;
    RectTransform graphTransform;

    Master masterScript;

    void Awake(){
        graphTransform = transform.Find("GraphContainer").GetComponent<RectTransform>();
        CreateDot(new Vector2(5,5));
        masterScript = GetComponentInParent<Master>();
    }


    // Update is called once per frame
    void Update()
    {
        dotRect.anchoredPosition = new Vector2((masterScript.GetVolume()-masterScript.GetMinVol())/(masterScript.GetMaxVol()-masterScript.GetMinVol())*225+5,(masterScript.GetPitch()-masterScript.GetMinPitch())/(masterScript.GetMaxPitch()-masterScript.GetMinPitch())*225+5);
    }

    void CreateDot(Vector2 anchoredPosition){
        dot = new GameObject("dot", typeof(Image));
        dot.transform.SetParent(graphTransform, false);
        dot.transform.GetComponent<Image>().sprite = circleSprite;
        dotRect = dot.GetComponent<RectTransform>();
        dotRect.anchoredPosition = anchoredPosition;
        dotRect.sizeDelta = new Vector2(11,11);
        dotRect.anchorMin = new Vector2(0,0);
        dotRect.anchorMax = new Vector2(0,0);
    }
}
