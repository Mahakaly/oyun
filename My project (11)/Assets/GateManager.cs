using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public int randomNumber;
    public bool multiply;
    // Start is called before the first frame update
    void Start()
    {
        if(multiply)
        {
            randomNumber = Random.Range(1, 3);

        }
        else
        {
            randomNumber=Random.Range(1,3);
            if(randomNumber %2!=0)
            {
                randomNumber += 1;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
