using LitJson;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    //[SerializedField] private GameOverScreen gameOverScreen;

    private GameManager gameManager;
    private IngameMenu ingameMenu;
    private float counter;
    private int time;

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
                time = (int)levelData[i]["time"];
            }
            
        }

        ingameMenu = GameObject.Find("IngameMenu").GetComponent<IngameMenu>();
        ingameMenu.SetTime(time);


        counter = 1f;
        updateGame = true;
    }

    public void ReachedFinishEvent()
    {
        CheckVictory();
    }

    public void RestartLevel()
    {

    }
	
	void Update () {
        if (updateGame)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                time--;
                ingameMenu.SetTime(time);
                counter = 1f;
            }

            CheckGameOver();
        }
	}

    private void CheckGameOver()
    {
        if(time <= 0)
        {
            Debug.Log("GAME OVER");
            updateGame = false;
        }
    }

    private void CheckVictory()
    {
        if(time > 0)
        {
            updateGame = false;
            victoryScreen.gameObject.SetActive(true);
        }
        victoryScreen.gameObject.SetActive(true);
    }
}
