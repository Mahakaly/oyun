using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public Rigidbody rb;

    public GameObject enemie;
    public int damageAmount=1;
    public float bulletLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
       
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(-1, 0, 0);
        transform.Translate(moveDir * force * Time.deltaTime);
        Destroy(gameObject, bulletLifeTime);
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
