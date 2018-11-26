using UnityEngine;

public class SettingsManager : MonoBehaviour {

    public float MusicVolume { get; internal set; }
    public float EffectsVolume { get; internal set; }
    public bool EnableMusic { get; internal set; }

    //Singleton
    public static SettingsManager instance;

    private void Awake()
    {
        //Create Singleton
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        LoadSettings();
    }

    private void LoadSettings()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        int enable = PlayerPrefs.GetInt("EnableMusic");
        if(enable == 1)
        {
            EnableMusic = true;
        }
        else
        {
            EnableMusic = false;
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolume);
        if (EnableMusic)
        {
            PlayerPrefs.SetInt("EnableMusic", 1);
        }
        else
        {
            PlayerPrefs.SetInt("EnableMusic", 0);
        }

        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().ChangeMusicVolume();
    }

    public void SetEffectsVolume(float volume)
    {
        EffectsVolume = volume;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().ChangeEffectsVolume();
    }

    public void SetMusicEnabled(bool enabled)
    {
        EnableMusic = enabled;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().EnableMusic(EnableMusic);
    }

}
