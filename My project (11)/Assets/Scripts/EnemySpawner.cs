using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;

   private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-200,-200),Random.Range(0.8f,0.8f),Random.Range(0f,-10f)), transform.rotation,transform);
            nextSpawnTime = Time.time + spawnRate;
        }
    }
  
}