using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip[] sfx;
    AudioSource audioSrc;
    float vol = 1f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        audioSrc.clip = sfx[1];
        audioSrc.PlayOneShot(audioSrc.clip,vol);
    }

    public void EnemyDeath()
    {
        audioSrc.clip = sfx[1];
        audioSrc.PlayOneShot(audioSrc.clip, vol);
    }

    public void ShootSFX()
    {
        audioSrc.clip = sfx[2];
        audioSrc.PlayOneShot(audioSrc.clip, vol);
    }

    public void SlashSFX()
    {
        audioSrc.clip = sfx[3];
        audioSrc.PlayOneShot(audioSrc.clip, vol);
    }
}
