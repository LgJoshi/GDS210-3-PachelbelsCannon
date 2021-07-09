using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRelay : MonoBehaviour
{
    Master masterScript;
    DataHolder dataScript;

    [SerializeField] float maxVol;
    [SerializeField] float minVol;
    [SerializeField] float maxPitch;
    [SerializeField] float minPitch;
    [SerializeField] string micNum;

    private void Awake()
    {
        masterScript = GameObject.Find("Master").GetComponent<Master>();
        dataScript=GameObject.Find("DataHolder").GetComponent<DataHolder>();
        maxVol=dataScript.GetMaxVol();
        minVol=dataScript.GetMinVol();
        maxPitch=dataScript.GetMaxPitch();
        minPitch=dataScript.GetMinPitch();
        micNum=dataScript.GetMicNum();
    }

    private void Start(){
        masterScript.SetMaxVolume(maxVol.ToString());
        masterScript.SetMinVolume(minVol.ToString());
        masterScript.SetMaxPitch(maxPitch.ToString());
        masterScript.SetMinPitch(minPitch.ToString());
        masterScript.SetMicNum(micNum);
    }

}
