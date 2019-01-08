using UnityEngine;

public class MenuState : GameState {

    public MenuState(Game manager) : base(manager)
    {
        EventListener.TriggerEvent("DisablePlayerInputEvent");
        Time.timeScale = 0;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PauseMusic();
    }

    public override void Update()
    {
    }
}
