using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour {

    public Slider musicVolume;
    public Slider effectsVolume;

    private SettingsManager settings;

    void Start()
    {
        settings = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
        musicVolume.value = settings.MusicVolume;
        musicVolume.onValueChanged.AddListener(delegate { MusicVolumeChange(); });

        effectsVolume.value = settings.EffectsVolume;
        effectsVolume.onValueChanged.AddListener(delegate { EffectsVolumeChange(); });
    }

    private void MusicVolumeChange()
    {
        settings.SetMusicVolume(musicVolume.value);
    }

    private void EffectsVolumeChange()
    {
        settings.SetEffectsVolume(effectsVolume.value);
    }

}
