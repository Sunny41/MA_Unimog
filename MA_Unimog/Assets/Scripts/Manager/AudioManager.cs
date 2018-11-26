using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {
    
    public Sound[] sounds;

    //Singleton
    public static AudioManager instance;

    private SettingsManager settings;

    void Awake()
    {
        //Create Singleton
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Settings instance
        settings = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();

        //Make gameObject persistent in all scenes
        DontDestroyOnLoad(gameObject);

        //Attach audioSource to sounds and set property values
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = settings.MusicVolume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.spatialBlend = sound.spatialBlend;
        }
    }

    void Start () {
        if(settings.EnableMusic)
            Play("MainTheme");
	}

    //Find a sound by it's name and play it
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void ChangeMusicVolume()
    {
        foreach (Sound sound in sounds)
        {
            if(sound.layer == 0)
                sound.source.volume = settings.MusicVolume;
        }
    }

    public void ChangeEffectsVolume()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.layer == 1)
                sound.source.volume = settings.EffectsVolume;
        }
    }

    public void EnableMusic(bool enable)
    {
        if (enable)
        {
            foreach (Sound sound in sounds)
            {
                if (sound.layer == 0)
                    sound.source.Play();
            }
        }
        else
        {
            foreach (Sound sound in sounds)
            {
                if (sound.layer == 0)
                    sound.source.Stop();
            }
        }
        
    }

}
