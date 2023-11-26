using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateManager : MonoBehaviour
{
    public int randomNumber;
    public bool multiply;

    public int numberToString;
    public string GateText;
    [SerializeField] private TMP_Text gateText =null;

    public int randomMax;
    public int randomMin;
    // Start is called before the first frame update
    void Start()
    {
      

        if(multiply)
        {
            randomNumber = numberToString;
            // gateText.text = "+" + randomNumber.ToString() + "\n" + GateText;
            gateText.text = "?";

        }
        else
        {
            randomNumber = numberToString;
            gateText.text = "+" + randomNumber.ToString() + "\n" + GateText;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
