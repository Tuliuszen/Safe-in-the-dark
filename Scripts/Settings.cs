using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider volumeSlider;
    SoundManager sManager;
    float volume;
    void Start()
    {
        if(volumeSlider == null)
            volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
        sManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        LoadSettings();
    }

    void Update()
    {
        SetVolume();
    }

    void SetVolume()
    {
        volume = volumeSlider.value;
        sManager.volume = volume;
    }

    void LoadSettings()
    {
        sManager.volume = PlayerPrefs.GetFloat("volume");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
}
