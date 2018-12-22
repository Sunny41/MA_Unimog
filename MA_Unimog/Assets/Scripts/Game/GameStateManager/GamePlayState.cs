using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    private CarAttributes carAttributes;
    private float secondCounter;
    private IngameMenu ingameMenu;
    private int levelTime;
    private int levelTimeCounter;

    public GamePlayState(Game game, IngameMenu ingameMenu, int levelTime, CarAttributes carAttribs) : base(game)
    {
        this.ingameMenu = ingameMenu;
        this.levelTime = levelTime;
        this.carAttributes = carAttribs;

        Initialize();
    }

    public void Initialize()
    {
        levelTimeCounter = levelTime;
        ingameMenu.SetTime(levelTime);
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
        if (levelTime <= 0 || carAttributes.GetFuelStatus() <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void CheckVictory()
    {
        
    }

}
