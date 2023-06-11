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

        Also referenced:
        SoundManager.cs from Assignment1

        Play sfx with FindObjectOfType<AudioManager>().PlaySFX("name");
        Play music with FindObjectOfType<AudioManager>().PlayMusic("name");
    */

    public Sound[] sfxClips, musicClips; 

    public static AudioManager instance;

    public float sfxVolume;
    public float musicVolume; 

    private Sound musicPlaying;

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

        sfxVolume = 1;
        musicVolume = 1;

        foreach(Sound s in sfxClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = this.sfxVolume * s.volume;
            s.source.loop = false;
        }

        foreach(Sound s in musicClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = this.musicVolume * s.volume;
            s.source.loop = true;
        }
    }

    void Start()
    {
        this.PlayMusic("BootCamp");
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

        if(this.musicPlaying != null)
        {
            this.musicPlaying.source.Stop();
        }

        s.source.Play();
        this.musicPlaying = s;
    } 
}
