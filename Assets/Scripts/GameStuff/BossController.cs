using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] GameObject meat;
    [SerializeField] float speed = 0.1f;
    [SerializeField] bool active=true;
    [SerializeField] int health=50;

    void Start(){
        StartCoroutine(MoveLeft());
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.name == "Cannonball(Clone)"){
            Destroy(collide.gameObject);
            Hurt();
        }
    }

    IEnumerator MoveLeft(){
        while (active){
            yield return new WaitForSeconds(0.1f);
            this.transform.position += new Vector3(-speed, 0, 0);        
        }

    }

    void Hurt(){
            health-=1;
            if (health<=0){
                Splatter();
            }
    }

    void Splatter(){
        for (int i=0; i<=50;i++){
            var newMeat= Instantiate(meat, this.transform.position, Quaternion.Euler(new Vector3(0,0,Random.Range(0,360))));
            float randomSpeed = Random.Range(100, 1000);
            float randomDirectionX = Random.Range(-1f, 1f);
            float randomDirectionY = Random.Range(-1f, 1f);
            newMeat.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(randomDirectionX,randomDirectionY)*randomSpeed);
            newMeat.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-500f, 500f));
        }
        EventManager.WinGame();
        Destroy(gameObject);
    }
}
