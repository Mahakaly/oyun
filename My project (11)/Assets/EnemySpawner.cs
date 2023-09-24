using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-171,-174),Random.Range(0.8f,0.8f),Random.Range(-4,4)), transform.rotation);
            nextSpawnTime = Time.time + spawnRate;
        }
    }
  
}