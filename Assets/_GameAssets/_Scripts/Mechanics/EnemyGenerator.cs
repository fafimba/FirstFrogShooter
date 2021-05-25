using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : TriggerByDistance
{

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    float spawnRate;
    [SerializeField]
    float radius = 5;
    [SerializeField]
    float spawnHeight = 1;
    [SerializeField]
    int maxEnemies;


    GameObject player;
    int enemyCounter = 0;
    bool isInvoking = false;

    void Awake()
    {
        player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        CheckTrigger();
            if (isInside && !isInvoking)
            {
                isInvoking = true;
                InvokeRepeating("CreateEnemy", spawnRate, spawnRate);
            }
    }

    void CreateEnemy()
    {
        Vector3 newEnemyPosition = transform.position;
        Vector2 randomPosition = Random.insideUnitCircle * radius;
        newEnemyPosition += new Vector3(randomPosition.x, spawnHeight, randomPosition.y);

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = newEnemyPosition;

        enemyCounter += 1;

        if (enemyCounter == maxEnemies)
        {
            isInvoking = false;
            enemyCounter = 0;
            CancelInvoke("CreateEnemy");
        }

    }
}
