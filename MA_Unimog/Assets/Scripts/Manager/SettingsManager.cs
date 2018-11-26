using UnityEngine;

public class SettingsManager : MonoBehaviour {

    public float MusicVolume { get; internal set; }
    public float EffectsVolume { get; internal set; }

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
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolume);

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

}
