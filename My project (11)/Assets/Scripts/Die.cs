using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject payerManager;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            Death();
           

        }
        if (other.gameObject.CompareTag("Boxes"))
        {
            Death();
        }
    }
   public void Death()
    {
        Destroy(gameObject);
    }
    
}
