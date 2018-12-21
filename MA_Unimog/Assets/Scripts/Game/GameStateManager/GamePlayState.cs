using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    private float secondCounter;
    private IngameMenu ingameMenu;
    private int levelTime;

    public GamePlayState(Game game, IngameMenu ingameMenu, int levelTime) : base(game)
    {
        this.ingameMenu = ingameMenu;
        this.levelTime = levelTime;

        Debug.Log("GAMEPLAY STATE");
    }

    public override void Update()
    {
        secondCounter -= Time.deltaTime;
        if (secondCounter <= 0)
        {
            levelTime--;
            ingameMenu.SetTime(levelTime);
            secondCounter = 1f;
        }

        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (levelTime <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void CheckVictory()
    {
        
    }

}
