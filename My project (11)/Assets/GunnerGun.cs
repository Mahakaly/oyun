using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerGun : MonoBehaviour
{
    public float firingRate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float timer;

    void Start()
    {
        timer = Random.Range(0f, firingRate);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
    }
}