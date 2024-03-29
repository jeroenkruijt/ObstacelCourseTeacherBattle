using UnityEngine;
using UnityEngine.Audio;
using System;

    public class AudioManager : MonoBehaviour
    {
        public Clips[] sounds;

    private void Awake()
    {
        foreach (Clips s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        Clips s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}