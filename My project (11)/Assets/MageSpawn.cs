using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSpawn : MonoBehaviour
{
    public GameObject CharacterSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CharacterSpawner.GetComponent<CharacterSpawn>().MageSpawner();
        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterSpawner.GetComponent<CharacterSpawn>().MageSpawner();
        }

    }*/
}
