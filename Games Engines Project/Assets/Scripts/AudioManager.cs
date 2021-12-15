using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        // For each sound in array
        foreach (Sound s in sounds)
        {
            // Get the audio source
            s.source = gameObject.AddComponent<AudioSource>();
            // Get audio clip
            s.source.clip = s.clip;

            // Get volume
            s.source.volume = s.volume;
            // Get pitch
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        // Find the song matching name passed as argument
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Play the song
        s.source.Play();
    }
}
