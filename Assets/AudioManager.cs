using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    /*
        Youtube videos referenced:
        "Unity AUDIO MANAGER Tutorial" - Rehope Games
        "Introduction to AUDIO in Unity" - Brackeys
    */

    public Sound[] sfxClips, musicClips; 

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sound s in sfxClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach(Sound s in musicClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //Play("Theme");
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxClips, x => x.name == name);
        if(s == null)
        {
            Debug.LogWarning("SFX sound \"" + name + "\" not found");
            return;
        }
        s.source.Play();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicClips, x => x.name == name);
        if(s == null)
        {
            Debug.LogWarning("Music sound \"" + name + "\" not found");
            return;
        }
        s.source.Play();
    }

    
}
