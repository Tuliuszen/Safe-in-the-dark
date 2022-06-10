using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float volume;
    public AudioSource audioSrc;
    void Start()
    {
        LoadVolume();
        audioSrc.loop = true;
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = volume;
    }

    public void LoadVolume()
    {
        volume = PlayerPrefs.GetFloat("volume");
        //if (volume > 0)
        //    musicOn = true;
    }
}
