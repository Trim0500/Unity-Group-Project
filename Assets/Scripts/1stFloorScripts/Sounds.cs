using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sounds
{
    public string name;
    public AudioClip AC;

    [Range(0f, 1f)]
    public float volume = .75f;

    [Range(0f, 1f)]
    public float volumeVariance = 1f;
    public bool loop = true;
    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource AS;
}
