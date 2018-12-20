using LitJson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    //[SerializedField] private GameOverScreen gameOverScreen;
    [SerializeField] private Text countdownTxt;

    private GameManager gameManager;
    private IngameMenu ingameMenu;
    private float secondCounter;
    private int levelTime;
    private int countDown;

    private bool updateGame;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        //Load unimog prefab
        GameObject obj = Instantiate(Resources.Load("Prefabs/Vehicles/" + gameManager.GetUnimogPrefabPath(), typeof(GameObject)), player.transform) as GameObject;
        obj.GetComponent<PlayerMovement>().controller = player.GetComponent<CharacterController2D>();
        obj.GetComponent<PlayerMovement>().driveJoystick = GameObject.Find("drive_joystick").GetComponent<FixedJoystick>();

        //Load level informations
        string sceneId = gameManager.GetSceneId();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        JsonData levelData = JsonMapper.ToObject(jsonFile.text);
        for(int i=0; i<levelData.Count; i++)
        {
            if(levelData[i]["sceneId"].ToString() == sceneId)
            {
                levelTime = (int)levelData[i]["time"];
            }
            
        }

        ingameMenu = GameObject.Find("IngameMenu").GetComponent<IngameMenu>();
        ingameMenu.SetTime(levelTime);


        secondCounter = 1f;
        updateGame = false;
        countDown = 3;
        countdownTxt.text = "" + countDown;
    }

    public void ReachedFinishEvent()
    {
        CheckVictory();
    }

    public void RestartLevel()
    {
        /*
        countdownTxt.gameObject.SetActive(false);
        countDown = 3;
        countdownTxt.text = "" + countDown;
        updateGame = false;
        StartLevelCountdown();
        */
        gameManager.LoadLevelScene();
    }
	
	void Update () {
        StartLevelCountdown();

        if (updateGame)
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
	}

    private void StartLevelCountdown()
    {
        if (updateGame)
        {
            return;
        }

        secondCounter -= Time.deltaTime;
        if(secondCounter <= 0 && countDown > 0)
        {
            secondCounter = 1f;
            countDown--;
            countdownTxt.text = "" + countDown;
        }

        if(countDown == 0)
        {
            countdownTxt.text = "Los!";
        }

        if(countDown == 0 && secondCounter <= 0)
        {
            updateGame = true;
            countdownTxt.gameObject.SetActive(false);
        }
    }

    private void CheckGameOver()
    {
        if(levelTime <= 0)
        {
            Debug.Log("GAME OVER");
            updateGame = false;
        }
    }

    private void CheckVictory()
    {
        if(levelTime > 0)
        {
            updateGame = false;
            victoryScreen.gameObject.SetActive(true);
        }
        victoryScreen.gameObject.SetActive(true);
    }
}
