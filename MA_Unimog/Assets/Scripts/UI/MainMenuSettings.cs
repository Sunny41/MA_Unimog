using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour {

    public Slider musicVolume;
    public Slider effectsVolume;
    public Toggle enableMusic;

    private SettingsManager settings;

    void Start()
    {
        settings = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
        musicVolume.value = settings.MusicVolume;
        musicVolume.onValueChanged.AddListener(delegate { MusicVolumeChange(); });

        effectsVolume.value = settings.EffectsVolume;
        effectsVolume.onValueChanged.AddListener(delegate { EffectsVolumeChange(); });

        enableMusic.isOn = settings.EnableMusic;

        //Deactivate menu-obj
        gameObject.SetActive(false);
    }

    private void MusicVolumeChange()
    {
        settings.SetMusicVolume(musicVolume.value);
    }

    private void EffectsVolumeChange()
    {
        settings.SetEffectsVolume(effectsVolume.value);
    }

    public void EnableDisableMusic()
    {
        settings.SetMusicEnabled(enableMusic.isOn);
    }

}
