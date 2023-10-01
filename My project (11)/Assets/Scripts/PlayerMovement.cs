using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public Vector3 movement;
    public GameObject bullet;
    public Transform firePoint;

    [SerializeField] private float firingRate = 1f;

    public Transform sniperr;
    public GameObject sniper;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       // movement = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(horizontalInput, 0, 0);
        transform.Translate(moveDir*speed*Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }
    void Fire()
    {
        Instantiate(bullet, firePoint.transform.position,Quaternion.identity);
    }
   
}
