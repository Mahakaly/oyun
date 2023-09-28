using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    private float explosionRadius=1f;
    private float maxDamage=3f;
    private float minDamage=2f;
    private float explosionForce=5f;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Exploded");
            Explode();

        }
       
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(ExplodeTimer());
        }
    }
    public void Explode()
    {
        Instantiate(explosion, rb.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Check if the object can take damage.
            Enemy damageable = hit.GetComponent<Enemy>();
            if (damageable != null)
            {
                // Calculate the damage based on distance from the explosion center.
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                float damage = Mathf.Lerp(maxDamage, minDamage, distance / explosionRadius);

                // Apply damage to the object.
                damageable.TakeDamage(3);
            }

            // Apply physics force to rigidbodies.
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

    }
    IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(1f);
        // Instantiate(explosion, rb.position, Quaternion.identity);
        Explode();
        Destroy(gameObject);
    }


}