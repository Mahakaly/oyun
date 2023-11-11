using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSkills : MonoBehaviour
{
    public GameObject spellPrefab;
    public float castInterval = 5f;
    private float timeSinceLastCast = 0f;
    private Transform nearestEnemy;
    private List<Transform> enemies;

    public GameObject spellTo;// List to store enemy Transforms

    void Start()
    {
        spellTo = GameObject.FindGameObjectWithTag("Ground").gameObject;
        // Populate the 'enemies' list with enemy Transforms (you can do this in various ways)
        // For example, you can tag your enemies with "Enemy" and find them using GameObject.FindGameObjectsWithTag.
      
    }

    void Update()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<Transform>(enemyObjects.Length);

        foreach (GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.transform);
        }
        // Check if it's time to cast a spell
        timeSinceLastCast += Time.deltaTime;
        if (timeSinceLastCast >= castInterval && enemies.Count > 0)
        {
            FindNearestEnemy();
            if (nearestEnemy != null)
            {
                CastSpell();
                timeSinceLastCast = 0f;
            }
        }
        
    }

    void FindNearestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        nearestEnemy = null;

        foreach (Transform enemy in enemies)
        {

            // Calculate the distance between the mage and the enemy
            float distance = Vector3.Distance(transform.position, enemy.position);

            // If this enemy is closer than the previously found closest enemy, update the nearestEnemy reference
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
        
    }

    void CastSpell()
    {
        Debug.Log("Spell casted"); // Instantiate the spell prefab at the mage's position and aim it at the nearestEnemy's position.
        GameObject spell = Instantiate(spellPrefab, nearestEnemy.transform.position, Quaternion.identity);
        spell.transform.SetParent(spellTo.transform);
        spell.transform.LookAt(nearestEnemy);
        
    }
}