using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
 

    [SerializeField] private GameObject finishText;

     public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerManager = GameObject.FindAnyObjectByType<PlayerManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Finisher());
            LevelManager.instance.NextLevel();
        }
    }
   private IEnumerator Finisher()
    {
        yield return new WaitForSeconds(1);

    }
   
}
