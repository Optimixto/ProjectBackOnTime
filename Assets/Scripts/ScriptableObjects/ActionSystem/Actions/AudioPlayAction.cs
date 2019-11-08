using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayAction : Action
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    protected override bool PerformAction()
    {
        audioSource.clip = audioClip;
        audioSource.Play();

        return true;
    }
}
