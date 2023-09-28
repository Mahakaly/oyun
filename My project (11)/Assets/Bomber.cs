using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public Transform targetTransform;
    public Transform firepointTransform;
    public float shootingForce;
    public GameObject bulletPrefab;

    public float firingRate;
    public GameObject explosion;

    
    

    private float timer;

    private void Start()
    {
        timer = Random.Range(0f, firingRate);
        // targetTransform = GameObject.FindGameObjectWithTag("bombtransa").transform;

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
       
        
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepointTransform.transform.position, transform.rotation);

        // Set the bullet's velocity to the shooting force multiplied by the direction vector from the player to the target transform.
        bullet.GetComponent<Rigidbody>().velocity = shootingForce * (targetTransform.position - transform.position).normalized;

        // Add the bullet object to the scene.
        
        

    }
   
    
}