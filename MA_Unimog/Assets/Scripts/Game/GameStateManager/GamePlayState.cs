using UnityEngine;

public class GamePlayState : GameState
{
    private CarAttributes carAttributes;
    private float secondCounter;
    private Level level;
    private int levelTimeCounter;

    public GamePlayState(Game game, Level level, CarAttributes carAttribs) : base(game)
    {
        this.level = level;
        this.carAttributes = carAttribs;

        Initialize();
    }

    public void Initialize()
    {
        EventListener.TriggerEvent("EnablePlayerInputEvent");

        levelTimeCounter = level.GetLevelTime();
        EventListener.TriggerEvent("SetLevelTimeEvent", levelTimeCounter);
        EventListener.TriggerEvent("SetFuelAmountEvent", carAttributes.GetFuelStatus());
        EventListener.TriggerEvent("SetBoxAmountEvent", carAttributes.GetBoxesAmount());
        carAttributes.SetBoxesAmount(level.GetUnimogBoxes());
    }

    public override void Update()
    {
        EventListener.TriggerEvent("EnablePlayerInputEvent");

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

    private void CheckGameOver()
    {
        if (levelTimeCounter <= 0 || carAttributes.GetFuelStatus() <= 0 || !carAttributes.GetCanDriveStatus())
        {
            EventListener.TriggerEvent("GameOverEvent");
        }
    }

}
