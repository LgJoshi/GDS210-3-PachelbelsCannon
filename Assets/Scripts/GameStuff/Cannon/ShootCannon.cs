using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    Master masterScript;
    bool active=true;

    float volume;
    float pitch;

    float maxVol;
    float minVol;
    float maxPitch;
    float minPitch;

    //stuff for calculating angles and speed based on mic input
    float angle;
    float xVector;
    float yVector;

    [SerializeField] float initDelay=0.3f;
    [SerializeField] float shootCooldown=1f;

    //power multipliers
    public float xPower;
    public float yPower;

    void OnEnable(){
        EventManager.BossPhased += ChangeCD;
    }
    void OnDisable(){
        EventManager.BossPhased -= ChangeCD;
    }

    void Start(){
        masterScript=GetComponentInParent<Master>();
        maxVol=masterScript.GetMaxVol();
        minVol=masterScript.GetMinVol();
        maxPitch=masterScript.GetMaxPitch();
        minPitch=masterScript.GetMinPitch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol&&active) {
            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall(){
        active = false;
        GetComponentInParent<CannonCooldownGauge>().Fired();
        yield return new WaitForSeconds(initDelay);
        var newBall = Instantiate(ballPrefab, this.transform.position, new Quaternion(0,0,0,0));
        CalculateAngle();
        GetComponentInParent<CannonCooldownGauge>().Cooled();
        CalculateVectors();
        this.transform.localRotation = Quaternion.Euler(new Vector3(0,0,angle*180/Mathf.PI));
        newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(xPower*xVector+20, yPower*yVector+30));
        yield return new WaitForSeconds(shootCooldown-initDelay);
        active=true;
    }

    void CalculateAngle(){
        pitch=masterScript.GetPitch();
        if (pitch>maxPitch) pitch = maxPitch;
        if (pitch<minPitch) pitch = minPitch;
        angle = 1.5708f/(maxPitch-minPitch)*(pitch-minPitch);
        Debug.Log("angle: " + angle);
    }

    void CalculateVectors(){
        volume=masterScript.GetVolume();
        if (volume>maxVol) volume=maxVol;
        if (volume<minVol) volume=minVol;
        yVector = Mathf.Sin(angle)*((volume-minVol)/(maxVol-minVol));
        xVector = Mathf.Cos(angle)*((volume-minVol)/(maxVol-minVol));
        Debug.Log("xVector: " + xVector);
        Debug.Log("yVector: " + yVector);
    }

    void ChangeCD(){
        initDelay=0.1f;
        shootCooldown=0.2f;
    }
}
