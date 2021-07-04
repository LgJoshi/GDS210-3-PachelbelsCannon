using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] GameObject meat;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        Debug.Log("collided with "+collide.gameObject.name);
        if (collide.gameObject.name == "Cannonball(Clone)"){
            Splatter();
        }
    }

    void Splatter(){
        Debug.Log("I splat!");
        for (int i=0; i<=20;i++){
            var newMeat= Instantiate(meat, this.transform.position, new Quaternion(0,0,Random.Range(0,180),0));
            float randomSpeed = Random.Range(100, 1000);
            float randomDirectionX = Random.Range(-1f, 1f);
            float randomDirectionY = Random.Range(-1f, 1f);
            newMeat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(randomDirectionX,randomDirectionY)*randomSpeed);
            newMeat.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-500f, 500f));
        }
        Destroy(gameObject);
    }
}
