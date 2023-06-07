using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*
        Youtube videos referenced:
        "Unity AUDIO MANAGER Tutorial" - Rehope Games
        "Introduction to AUDIO in Unity" - Brackeys
    */

    public Sound[] SFXclips, Musicclips; 

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == NULL)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sound s in sounds)
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
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sound.name == name);
        if(s == NULL)
        {
            Debug.LogWarning("Sound \"" + name + "\" not found");
            return;
        }
        s.source.Play();
    }
}
