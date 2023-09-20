using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health=1;
    public float speed;
    public float rotationSpeed = 40f;
    public float detectionRange = 1f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       if(target != null) {
            float distanceToTarget = Vector3.Distance(transform.position, target.position); 
            if(distanceToTarget <= rotationSpeed) { 

            Vector3 targetDir = target.position-transform.position;
            targetDir.y = 0f;
            transform.LookAt(target, Vector3.up);
            }
           // Quaternion rotation = Quaternion.LookRotation(targetDir);
           // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);
        }
        Vector3 moveDir = new Vector3(0, 0, 1f);
        transform.Translate(moveDir * speed * Time.deltaTime);

    }
   public void TakeDamage(int damageAmount)
    {
       health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
