using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    float volume;
    float pitch;
    bool active=true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator SpawnBall(){
        while (active) {
            yield return new WaitForSeconds(0.5f);
            var newBall = Instantiate(ballPrefab, this.transform.position, new Quaternion(0,0,0,0));
            newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 5f));
        }
    }
}
