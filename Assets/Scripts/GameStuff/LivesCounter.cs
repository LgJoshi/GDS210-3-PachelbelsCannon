using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] int lives=4;
    [SerializeField] GameObject[] hearts;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Enemy(Clone)"){
            lives-=1;
            Destroy(hearts[lives]);
            if (lives <= 0){
                SceneManager.LoadScene("GameOver");
            }
        } else if(col.gameObject.name == "Boss(Clone)"){
            SceneManager.LoadScene("GameOver");
        }
        Destroy(col.gameObject);
    }
}
