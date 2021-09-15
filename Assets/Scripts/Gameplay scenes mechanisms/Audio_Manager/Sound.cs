using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;
    public bool loop;

    [Range(0f,1f)]
    public float Pitch;
    [Range(0f,1f)]
    public float Volume;
    

    [HideInInspector]
    public AudioSource source;

    public AudioMixerGroup output;
    
}
