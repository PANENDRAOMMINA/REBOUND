using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music_Player : MonoBehaviour
{
    public AudioMixer Game_Mixer;
    public float master_volume;

    // Start is called before the first frame update
    void Start()
    {
        master_volume = PlayerPrefs.GetFloat("Master_Volume", -80);
        Game_Mixer.SetFloat("Master_Volume", master_volume);
        DontDestroyOnLoad(this.gameObject);
    }
}
