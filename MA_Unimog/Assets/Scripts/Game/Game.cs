using LitJson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    //controllables
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private Text countdownTxt;
    [SerializeField] private IngameMenu ingameMenu;
    [SerializeField] private InputManager inputManager;

    private GamePlayState gamePlayState;

    //private stuff
    private GameState currentState;
    private GameManager gameManager;
    private float secondCounter;
    private int levelTime;
    private int countDown;

    private bool updateGame;

    void Start () {
        InitializeLevel();
    }

    public void ReachedFinishEvent()
    {
    }
    
    public void RestartLevel()
    {
        gameManager.LoadLevelScene();

        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        //Load level informations
        string sceneId = gameManager.GetSceneId();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        JsonData levelData = JsonMapper.ToObject(jsonFile.text);
        for (int i = 0; i < levelData.Count; i++)
        {
            if (levelData[i]["sceneId"].ToString() == sceneId)
            {
                levelTime = (int)levelData[i]["time"];
            }

        }

        ingameMenu.SetTime(levelTime);

        gamePlayState = new GamePlayState(this, ingameMenu, levelTime);
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
        
        //Load level informations
        string sceneId = gameManager.GetSceneId();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        JsonData levelData = JsonMapper.ToObject(jsonFile.text);
        for (int i = 0; i < levelData.Count; i++)
        {
            if (levelData[i]["sceneId"].ToString() == sceneId)
            {
                levelTime = (int)levelData[i]["time"];
            }

        }

        ingameMenu.SetTime(levelTime);

        gamePlayState = new GamePlayState(this, ingameMenu, levelTime);
    }

    public void LoadMainMenu()
    {
        gameManager.LoadMenuScene();
    }

    public void LoadNextLevel()
    {

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
