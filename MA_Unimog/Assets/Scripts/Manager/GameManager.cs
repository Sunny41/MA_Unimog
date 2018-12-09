using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    private string unimogPrefabPath;
    private string sceneId;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject unimogSelectMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject galerieMenu;

    //Singleton
    public static GameManager instance;

    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(this.gameObject);
            SetPortraitRotation();
        }

        //activate all menus. They deactivate them self after theri initialisation
        mainMenu.SetActive(true);
        unimogSelectMenu.SetActive(true);
        levelSelectMenu.SetActive(true);
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(true);
        galerieMenu.SetActive(true);
    }

    private void SetPortraitRotation()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void SetLandscapeOrientation()
    {
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        SetPortraitRotation();
    }

    public void LoadLevelScene()
    {
        Debug.Log("Load LevelID: " + sceneId);
        Debug.Log("Load UnimogPrefab: " + unimogPrefabPath);

        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);   
        SetLandscapeOrientation();
    }

    public void SetUnimogPrefabPath(string prefabPath)
    {
        this.unimogPrefabPath = prefabPath;
    }

    public void SetSceneId(string id)
    {
        this.sceneId = id;
    }
    
    public string GetUnimogPrefabPath()
    {
        return unimogPrefabPath;
    }

    public string GetSceneId()
    {
        return sceneId;
    }
}
