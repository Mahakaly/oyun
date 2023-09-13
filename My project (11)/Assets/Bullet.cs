using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(-1, 0, 0);
        transform.Translate(moveDir * force * Time.deltaTime);
    }
}
