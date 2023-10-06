using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListen : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
