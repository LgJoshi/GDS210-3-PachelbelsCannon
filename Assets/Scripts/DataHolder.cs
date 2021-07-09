using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    private static DataHolder instance;
    public static DataHolder Instance
    {
        get { return instance; }
    }
    
    Master masterScript;

    public float maxVol;
    public float minVol;
    public float maxPitch;
    public float minPitch;
    public string micNum;

    private void Awake()
    {
        // If no Player ever existed, we are it.
        if (instance == null)
            instance = this;
        // If one already exist, it's because it came from another level.
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        masterScript = GameObject.Find("MenuMaster").GetComponent<Master>();
    }

    public void GrabValues(){
        maxVol=masterScript.GetMaxVol();
        minVol=masterScript.GetMinVol();
        maxPitch=masterScript.GetMaxPitch();
        minPitch=masterScript.GetMinPitch();
        micNum=masterScript.GetMicNum().ToString();
    }

    public float GetMaxVol(){
        return maxVol;
    }
    public float GetMinVol(){
        return minVol;
    }
    public float GetMaxPitch(){
        return maxPitch;
    }
    public float GetMinPitch(){
        return minPitch;
    }
    public string GetMicNum(){
        return micNum;
    }
}
