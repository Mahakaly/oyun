using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject spawnPrefabSniper;
    public GameObject spawnPrefabMage;
    public float spawnRadius = 1.0f;
    public GameObject mageSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }
   /* public void SniperSpawner()
    {
        Instantiate(spawnPrefabSniper,gameObject.transform.position , spawnPrefabSniper.transform.rotation);

    }*/
    public void SniperSpawner()
    {
        Vector3 targetPosition = gameObject.transform.position;
        targetPosition.y = 0;

        // Rastgele bir pozisyon oluþturun sadece x ve z düzlemi üzerinde
        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;

        // Hedef pozisyonu rastgele ofset ile güncelleyin
        Vector3 spawnPosition = targetPosition + new Vector3(randomOffset.x, 0, randomOffset.y);

        // Oluþturulan pozisyonda objeyi instantiate edin
        Instantiate(spawnPrefabSniper, spawnPosition, spawnPrefabSniper.transform.rotation);
    }
    public void MageSpawner()
    {
        Vector3 targetPosition = mageSpawnPoint.transform.position;
        targetPosition.y = 0;

        // Rastgele bir pozisyon oluþturun sadece x ve z düzlemi üzerinde
        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;

        // Hedef pozisyonu rastgele ofset ile güncelleyin
        Vector3 spawnPosition = targetPosition + new Vector3(randomOffset.x, 0, randomOffset.y);

        // Oluþturulan pozisyonda objeyi instantiate edin
        Instantiate(spawnPrefabMage, spawnPosition, spawnPrefabMage.transform.rotation);
        // Instantiate(spawnPrefabMage, new Vector3(Random.Range(-146, -144), Random.Range(0, 0), Random.Range(1, -1)), spawnPrefabMage.transform.rotation);
    }
    
    /* public void SniperSpawner(GameObject targetObject)
     {
         // Define your random offset range
         float xOffset = Random.Range(1, -1); // Adjust these values to control the range
         float yOffset = Random.Range(0, 0); // Adjust these values to control the range
         float zOffset = Random.Range(-1, -1); // Adjust these values to control the range

         // Calculate the spawn position based on the targetObject's position and random offsets
         Vector3 spawnPosition = targetObject.transform.position + new Vector3(xOffset, yOffset, zOffset);

         // Spawn the sniper prefab at the calculated position
         Instantiate(spawnPrefabSniper, spawnPosition, spawnPrefabSniper.transform.rotation);
     */
}

