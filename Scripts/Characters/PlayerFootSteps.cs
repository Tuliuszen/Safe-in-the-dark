using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    AudioSource footStepsAudio;
    public AudioClip[] stepClips;
    public AudioClip[] jumpClips;
    void Awake()
    {
        footStepsAudio = GetComponent<AudioSource>();
    }

    public void PlayerStep()
    {
        footStepsAudio.PlayOneShot(GetRandomStepClip());
    }

    public void PlayerJump()
    {
        footStepsAudio.PlayOneShot(GetRandomJumpClip());
    }

    private AudioClip GetRandomStepClip()
    {
        return stepClips[Random.Range(0, stepClips.Length)];
    }

    private AudioClip GetRandomJumpClip()
    {
        return jumpClips[Random.Range(0, jumpClips.Length)];
    }
}
