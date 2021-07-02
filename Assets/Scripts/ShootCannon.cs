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

    public float maxVol;
    public float minVol;
    public float maxPitch;
    public float minPitch;

    //stuff for calculating angles and speed based on mic input
    float angle;
    float xVector;
    float yVector;

    //power multipliers
    public float xPower;
    public float yPower;

    void Awake(){
        masterScript=GetComponentInParent<Master>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume=masterScript.GetVolume();
        if (volume>minVol&&active) {
            SpawnBall();
            StartCoroutine(SpawnBall());
        }
    }

    IEnumerator SpawnBall(){
        active = false;
        yield return new WaitForSeconds(0.25f);
        var newBall = Instantiate(ballPrefab, this.transform.position, new Quaternion(0,0,0,0));
        CalculateAngle();
        CalculateVectors();
        newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(xPower*xVector, yPower*yVector));
        yield return new WaitForSeconds(0.5f);
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
        yVector = Mathf.Sin(angle)*(volume-minVol);
        xVector = Mathf.Cos(angle)*(volume-minVol);
        Debug.Log("xVector: " + xVector);
        Debug.Log("yVector: " + yVector);
    }
}
