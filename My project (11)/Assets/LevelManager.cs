using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int currentLevel=0;
     
    public List<Level> level = new List<Level>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        level[currentLevel].gameObject.SetActive(true);
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void NextLevel()
    {
        level[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        level[currentLevel].gameObject.SetActive(true);

    }
}
