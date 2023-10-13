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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Finisher());
        }
    }
    IEnumerator Finisher()
    {
        yield return new WaitForSeconds(0.1f);
        spawner.SetActive(false);
        yield return new WaitForSeconds(3);
        playerManager.roadMoving = false;
        
        yield return new WaitForSeconds(2f);
        finishText.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
    }
}
