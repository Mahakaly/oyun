using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateManager : MonoBehaviour
{
    public int randomNumber;
    public bool multiply;
    public int numberToString;
    [SerializeField] private TMP_Text gateText =null;
    // Start is called before the first frame update
    void Start()
    {
      

        if(multiply)
        {
            randomNumber = numberToString;
            gateText.text = "+" + randomNumber.ToString() + "\n Gunner";

        }
        else
        {
            randomNumber = numberToString;
            gateText.text = "+" + randomNumber.ToString() + "\n Gunner";

            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
