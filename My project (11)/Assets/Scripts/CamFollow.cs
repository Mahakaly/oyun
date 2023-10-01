using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    float speed = 4f;
    private void Update()
    {
        Vector3 moveDir = new Vector3(1, 0, 0);
        transform.Translate(moveDir * speed * Time.deltaTime);
    }
}
