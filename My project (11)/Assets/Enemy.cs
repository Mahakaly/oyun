using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth=3f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 1f);
        transform.Translate(moveDir * speed * Time.deltaTime);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        health--;
        Destroy(other.gameObject);
    }
}
