using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnInterval = 3f;
    private float spawnTimer = 0f;
    public float spawnRadius = 10f;
    public Transform[] spawnPoints;
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            TrySpawnEnemy();
        }
    }

    void TrySpawnEnemy()
    {
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (currentEnemies >= maxEnemies)
            return;

        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnPos = point.position;
        }
        else
        {
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            spawnPos = new Vector3(
                transform.position.x + randomPos.x,
                transform.position.y,
                transform.position.z + randomPos.y
            );
        }

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
