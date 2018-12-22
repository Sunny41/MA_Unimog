﻿using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    //controllables
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private Text countdownTxt;
    [SerializeField] private IngameMenu ingameMenu;
    [SerializeField] private InputManager inputManager;

    //Current level
    private Level currentLevel;

    //private stuff
    private GameState currentState;
    private GameManager gameManager;
    private GamePlayState gamePlayState;

    void Start () {
        InitializeLevel();
    }

    public void ReachedFinishEvent()
    {
    }
    
    public void RestartLevel()
    {
        SetCountdownState();

        gameManager.LoadLevelScene();

        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        gamePlayState.Initialize();
    }

    private void InitializeLevel()
    {
        SetCountdownState();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        //Load unimog prefab
        GameObject obj = Instantiate(Resources.Load("Prefabs/Vehicles/" + gameManager.GetUnimogPrefabPath(), typeof(GameObject)), player.transform) as GameObject;
        CarAttributes carAttribs = obj.GetComponent<CarAttributes>();

        //Load level informations
        currentLevel = new Level(gameManager.GetSceneId());

        gamePlayState = new GamePlayState(this, ingameMenu, currentLevel, carAttribs);
    }

    public void LoadMainMenu()
    {
        gameManager.LoadMenuScene();
    }

    public void LoadNextLevel()
    {
        Level nextLevel = currentLevel.NextLevel();
        if(nextLevel != null)
        {
            Debug.Log("Load next level " + nextLevel.GetId() + " " + nextLevel.GetSceneId());
            //gameManager.LoadLevel(nextLevel.GetSceneId());
        }
        else
        {
            Debug.Log("THERE IS NO NEXT LEVEL");
        }
        
    }
   
    void Update()
    {
        currentState.Update();
    }

    public void SetGamePlayState()
    {
        currentState = gamePlayState;
        inputManager.EnableInput();
    }

    public void SetMenuState()
    {
        currentState = new MenuState(this, ingameMenu);
        inputManager.DisableInput();
    }

    public void SetCountdownState()
    {
        currentState = new CountdownState(this, countdownTxt);
        inputManager.DisableInput();
    }
    
}
