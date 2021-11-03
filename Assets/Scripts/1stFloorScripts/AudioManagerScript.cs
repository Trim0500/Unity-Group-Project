using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript audioManager;
    public AudioMixerGroup mixerGroup;
    public Sounds[] sounds;


    // Start is called before the first frame update
    void Start()
    {
        if (audioManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach(Sounds S in sounds)
        {
            S.AS = gameObject.AddComponent<AudioSource>();
            S.AS.clip = S.AC;
            S.AS.loop = S.loop;
            S.AS.outputAudioMixerGroup = S.mixerGroup;
        }

        sounds[0].AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string sound)
    {
        Sounds s = Array.Find(sounds, item => item.name == sound);
        if(s == null)
        {
            Debug.Log("Sound " + s + " is empty.");
        }

        s.AS.volume = s.volume;

        s.AS.Play();
    }

    public void Play(int soundIndex)
    {
        Sounds currentSound;

        foreach(Sounds temp in sounds)
        {
            if(temp.AS.isPlaying)
            {
                currentSound = temp;
                currentSound.AS.Stop();
            }
        }

        Sounds s = sounds[soundIndex];

        s.AS.Play();
    }
}
