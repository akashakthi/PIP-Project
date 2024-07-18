using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    AudioManager instance;
    public AudioClip trueClip;
    public AudioClip falseClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void trueAnswersAudio()
    {
        audioSource.PlayOneShot(trueClip);
    }

    public void falseAnswersAudio()
    {
        audioSource.PlayOneShot(falseClip);
    }
}
