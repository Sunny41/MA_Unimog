using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public Sound[] sounds;

    private Sound currentSound;

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        if(currentSound != null && currentSound.name.Equals(name))
        {
            return;
        }

        if(currentSound != null)
        {
            currentSound.source.Stop();
        }
        
        currentSound = s;
        currentSound.source.Play();
    }

    public void Increase(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        if (currentSound == null)
        {
            currentSound = s;
            currentSound.source.Play();
        }

        currentSound.volume += Time.deltaTime;
        if(currentSound.volume >= 1)
        {
            currentSound.volume = 1;
        }
        Debug.Log(currentSound.volume);
    }

    public void Decrease(string name)
    {
        if(currentSound != null)
        {
            currentSound.volume -= Time.deltaTime;
            if (currentSound.volume <= 0.25)
            {
                currentSound.volume = 0.25f;
            }
        }
        
    }
}
