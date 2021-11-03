using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip AC;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
        AS.clip = AC;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayMusic()
    {
        AS.Play();
    }
}
