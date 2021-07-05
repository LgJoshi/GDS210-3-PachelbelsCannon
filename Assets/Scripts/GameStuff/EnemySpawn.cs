using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay=3f;
    Vector2 screenBounds;
    bool gameStart=true;

    void Awake()
    {
        screenBounds=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void StartWave(){
        StartCoroutine(AnimalWave());
    }

    IEnumerator AnimalWave(){
        while (gameStart){
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }   
    }

    void SpawnEnemy(){
        var newEnemy= Instantiate(enemyPrefab, new Vector3(screenBounds.x, Random.Range(-screenBounds.y+1, screenBounds.y-1), 5), new Quaternion(0,0,0,0));
    }
}
