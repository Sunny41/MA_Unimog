using UnityEngine;

public class GamePlayState : GameState
{
    private CarAttributes carAttributes;
    private float secondCounter;
    private IngameMenu ingameMenu;
    private Level level;
    private int levelTimeCounter;

    public GamePlayState(Game game, IngameMenu ingameMenu, Level level, CarAttributes carAttribs) : base(game)
    {
        this.ingameMenu = ingameMenu;
        this.level = level;
        this.carAttributes = carAttribs;

        Initialize();
    }

    public void Initialize()
    {
        levelTimeCounter = level.GetLevelTime();
        ingameMenu.SetTime(levelTimeCounter);
        ingameMenu.SetBoxAmount(carAttributes.GetBoxesAmount());
        ingameMenu.SetFuel(carAttributes.GetFuelStatus());
    }

    public override void Update()
    {
        secondCounter -= Time.deltaTime;
        if (secondCounter <= 0)
        {
            levelTimeCounter--;
            ingameMenu.SetTime(levelTimeCounter);
            secondCounter = 1f;
        }

        ingameMenu.SetFuel(carAttributes.GetFuelStatus());

        ingameMenu.SetBoxAmount(carAttributes.GetBoxesAmount());

        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (levelTimeCounter <= 0 || carAttributes.GetFuelStatus() <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void CheckVictory()
    {
        
    }

}
