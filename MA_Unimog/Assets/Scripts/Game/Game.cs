using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    //controllables
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private Text countdownTxt;

    //Current level
    private Level currentLevel;

    //private stuff
    private GameState currentState;
    private GameManager gameManager;
    private GamePlayState gamePlayState;
    private UnityAction restartListener;
    private UnityAction openInventoryListener;
    private UnityAction closeInventoryListener;

    void Awake()
    {
        restartListener = new UnityAction(RestartLevel);
        openInventoryListener = new UnityAction(SetMenuState);
        closeInventoryListener = new UnityAction(SetGamePlayState);

        EventListener.StartListening("RestartLevelEvent", restartListener);
        EventListener.StartListening("OpenInventoryEvent", openInventoryListener);
        EventListener.StartListening("CloseInventoryEvent", closeInventoryListener);
    }

    void Start()
    {
        InitializeLevel();
    }

    private void RestartLevel()
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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        //Load unimog prefab
        GameObject obj = Instantiate(Resources.Load("Prefabs/Vehicles/" + gameManager.GetUnimogPrefabPath(), typeof(GameObject)), player.transform) as GameObject;
        CarAttributes carAttribs = obj.GetComponent<CarAttributes>();

        //spawn boxes on cargoCheck
        Transform cargoCheck = GameObject.Find("cargoCheck").GetComponent<Transform>();
        for (int i = 0; i < 2; i++) // amount of boxes from JSON
        {
            GameObject box = Instantiate(Resources.Load("Prefabs/Objects/Box"), new Vector3(cargoCheck.position.x, cargoCheck.position.y + 0.5f, cargoCheck.position.z), Quaternion.identity) as GameObject;
        }

        //Load level informations
        currentLevel = new Level(gameManager.GetSceneId());

        gamePlayState = new GamePlayState(this, currentLevel, carAttribs, victoryScreen, gameOverScreen);

        SetCountdownState();
    }

    public void LoadMainMenu()
    {
        gameManager.LoadMainMenuScene();
    }

    public void LoadNextLevel()
    {
        //Load level select menu
        GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound();
        gameManager.LoadMainMenuLevelSelectScene();
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetGamePlayState()
    {
        currentState = gamePlayState;
        gamePlayState.Init();
    }

    public void SetMenuState()
    {
        currentState = new MenuState(this);
    }

    public void SetCountdownState()
    {
        currentState = new CountdownState(this, countdownTxt);
    }



}
