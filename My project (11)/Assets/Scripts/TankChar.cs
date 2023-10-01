using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChar : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool isRushing=false;

    public int maxHealth=5;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRushing)
        {
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            col.isTrigger = true;
            isRushing = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            maxHealth--;
            if(maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

