using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] float spawnDelay=1.5f;
    Vector2 screenBounds;
    bool gameStart=true;

    bool timerStart;
    [SerializeField] float timer=0;
    float bossTime=40f;

    void Update(){
        if(timerStart){
            timer+=Time.deltaTime;
            if (timer>=bossTime){
                timerStart=false;
                EventManager.StartBoss();
            }
        }
    }
    

    void OnEnable(){
        EventManager.BossPhased += StopSpawn;
        EventManager.BossPhased += SpawnBoss;
        EventManager.GameStarted += StartWave;
    }

    void OnDisable(){
        EventManager.BossPhased -= StopSpawn;
        EventManager.BossPhased -= SpawnBoss;
        EventManager.GameStarted -= StartWave;
    }

    void Awake()
    {
        screenBounds=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void StartWave(){
        StartCoroutine(AnimalWave());
        timerStart=true;
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

    void StopSpawn(){
        gameStart=false;
    }

    void SpawnBoss(){
        var newEnemy= Instantiate(bossPrefab, new Vector3(screenBounds.x+5, (-screenBounds.y+screenBounds.y)/2, 5), new Quaternion(0,0,0,0));
    }
}
