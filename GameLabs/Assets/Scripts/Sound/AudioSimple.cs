using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSimple : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void PlayAudio()

    {
        audioSource.PlayOneShot(clip, volume);
    }
}
