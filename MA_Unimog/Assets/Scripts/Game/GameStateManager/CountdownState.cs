using UnityEngine;
using UnityEngine.UI;

public class CountdownState : GameState {

    private float secondCounter;
    private int countDown;
    private Text countdownTxt;

    public CountdownState(Game manager, Text countdownTxt) : base(manager)
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("MainTheme_game");
        EventListener.TriggerEvent("EnablePlayerInputEvent");
        EventListener.TriggerEvent("DeactivatePlayerInputEvent");
        this.countdownTxt = countdownTxt;
        countdownTxt.gameObject.SetActive(true);
        secondCounter = 1f;
        countDown = 3;
        countdownTxt.text = "" + countDown;
        Time.timeScale = 1;
    }

    public override void Update()
    {
        EventListener.TriggerEvent("EnablePlayerInputEvent");
        EventListener.TriggerEvent("DeactivatePlayerInputEvent");

        secondCounter -= Time.deltaTime;
        if (secondCounter <= 0 && countDown > 0)
        {
            secondCounter = 1f;
            countDown--;
            countdownTxt.text = "" + countDown;
        }

        if (countDown == 0)
        {
            countdownTxt.text = "Los!";
        }

        if (countDown == 0 && secondCounter <= 0)
        {
            countdownTxt.gameObject.SetActive(false);
            countdownTxt.text = "";
            game.SetGamePlayState();
        }
    }
}
