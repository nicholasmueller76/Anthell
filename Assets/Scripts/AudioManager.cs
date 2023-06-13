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
            or for looping option: FindObjectOfType<AudioManager>().PlaySFX("name", bool loop);

        Play music with FindObjectOfType<AudioManager>().PlayMusic("name");

        To stop SFX: FindObjectOfType<AudioManager>().StopSFX("name");
        To stop Music: FindObjectOfType<AudioManager>().StopMusic();
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
            s.source.pitch = s.pitch;
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

    //Boolean indicates whether the sound should be looped
    public void PlaySFX(string name, bool loop)
    {
        Sound s = Array.Find(sfxClips, x => x.name == name);
        if(s == null)
        {
            Debug.LogWarning("SFX sound \"" + name + "\" not found");
            return;
        }
        s.source.loop = loop;
        s.source.Play();
    }

    public void PlaySFX(string[] names)
    {
        PlaySFX(names[UnityEngine.Random.Range(0, names.Length)]);
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

    public void StopSFX(string name)
    {
        Sound s = Array.Find(sfxClips, x => x.name == name);

        if(s == null)
        {
            Debug.LogWarning("Music sound \"" + name + "\" not found");
            return;
        }
        s.source.Stop();
    }

    public void StopMusic()
    {
        if(this.musicPlaying != null)
        {
            this.musicPlaying.source.Stop();
        }
    }
}
