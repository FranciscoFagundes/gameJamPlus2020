using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemies;
    public float currentTime;
    public float timeForRespawn;
    public int enemyNumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timeForRespawn) {
             currentTime = 0;
             SpawnEnemy();
        }
       
    }

    void SpawnEnemy() {
        enemyNumber = Random.Range(0,10);
        Instantiate(enemies[enemyNumber], transform.position, Quaternion.identity);
    }
}
