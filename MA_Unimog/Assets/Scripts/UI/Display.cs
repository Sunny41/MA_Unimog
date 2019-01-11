using UnityEngine;

public abstract class Display : MonoBehaviour {

    protected AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

	public void PlayMenuSlectSound()
    {
        audioManager.Play("menu_selection");
    }
}
