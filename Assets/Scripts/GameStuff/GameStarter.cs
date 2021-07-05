using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collide)
    {
        Debug.Log("collided with "+collide.gameObject.name);
        if (collide.gameObject.name == "Cannonball(Clone)"){
            GetComponentInParent<EnemySpawn>().StartWave();
        }
    }
}
