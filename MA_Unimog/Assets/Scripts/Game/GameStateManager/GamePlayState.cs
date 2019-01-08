using UnityEngine;
using UnityEngine.Events;

public class GamePlayState : GameState
{
    private CarAttributes carAttributes;
    private float secondCounter;
    private Level level;
    private int levelTimeCounter;
    private bool victory;
    private bool gameOver;
    private UnityAction victoryListener;
    private VictoryScreen victoryScreen;
    private GameOverScreen gameOverScreen;

    public GamePlayState(Game game, Level level, CarAttributes carAttribs, VictoryScreen victoryScreen, GameOverScreen gameOverScreen)
        : base(game)
    {
        this.level = level;
        this.carAttributes = carAttribs;
        this.victoryScreen = victoryScreen;
        this.gameOverScreen = gameOverScreen;
        Initialize();
    }

    public void Initialize()
    {
        EventListener.TriggerEvent("EnablePlayerInputEvent");

        Time.timeScale = 1;
        gameOver = false;
        victory = false;
        victoryListener = new UnityAction(Victory);
        levelTimeCounter = level.GetLevelTime();
        EventListener.TriggerEvent("SetLevelTimeEvent", levelTimeCounter);
        EventListener.TriggerEvent("SetFuelAmountEvent", carAttributes.GetFuelStatus());
        EventListener.TriggerEvent("SetBoxAmountEvent", carAttributes.GetBoxesAmount());
        carAttributes.SetBoxesAmount(level.GetUnimogBoxes());
        EventListener.StartListening("VictoryEvent", victoryListener);
    }

    public override void Update()
    {
       

        if (!victory && !gameOver)
        {
            secondCounter -= Time.deltaTime;
            if (secondCounter <= 0)
            {
                levelTimeCounter--;
                EventListener.TriggerEvent("SetLevelTimeEvent", levelTimeCounter);
                secondCounter = 1f;
            }

            EventListener.TriggerEvent("SetFuelAmountEvent", carAttributes.GetFuelStatus());
            EventListener.TriggerEvent("SetBoxAmountEvent", carAttributes.GetBoxesAmount());

            CheckGameOver();
        }

    }

    public void Init()
    {
        Time.timeScale = 1;
        EventListener.TriggerEvent("EnablePlayerInputEvent");
        EventListener.TriggerEvent("ActivatePlayerInputEvent");
        GameObject.Find("AudioManager").GetComponent<AudioManager>().UnpauseMusic();
    }

    private float CalculateRating()
    {
        return carAttributes.GetBoxesAmount() + levelTimeCounter;
    }

    private void Victory()
    {
        victory = true;
        victoryScreen.gameObject.SetActive(true);
        victoryScreen.SetRating(CalculateRating());
        //Unlock next level. Save data
        GameObject.Find("GameManager").GetComponent<GameManager>().UnlockLevel(level, CalculateRating());
    }

    private void CheckGameOver()
    {
        if (levelTimeCounter <= 0 || carAttributes.TippedOver())
        {
            gameOver = true;
            gameOverScreen.gameObject.SetActive(true);
        }
    }

}
