using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    public float master_volume;
    public Slider Audio_Slider;
    public AudioMixer Game_mixer;

    public void Start()
    {
        Audio_Slider.value = PlayerPrefs.GetFloat("Master_Volume");
        Game_mixer.SetFloat("Master_Volume", Audio_Slider.value);
    }

    public void On_change_volume()
    {
        Game_mixer.SetFloat("Master_Volume", Audio_Slider.value);
        PlayerPrefs.SetFloat("Master_Volume",Audio_Slider.value);
        Audio_Slider.value = PlayerPrefs.GetFloat("Master_Volume");
    }
}
