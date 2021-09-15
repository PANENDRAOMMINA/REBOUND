using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Audio_sounds : MonoBehaviour
{
    public Sound[] sounds;

    public static Audio_sounds instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
   
        foreach(Sound s in sounds)
        {
           s.source= gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.Volume;
           s.source.pitch = s.Pitch;
           s.source.loop = s.loop;
           s.source.outputAudioMixerGroup = s.output;
        }
    }

    public void Play(string name)
    {
        Sound s=Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
