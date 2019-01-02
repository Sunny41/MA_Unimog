using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    private string unimogPrefabPath;
    private string sceneId;
    private MenuDisplay menuDisplay;

    [SerializeField] private MainMenu mainMenu;

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
        menuDisplay = MenuDisplay.MainMenu;
        mainMenu.InitializeMainMenu();
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

    public void LoadMainMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        SetPortraitRotation();
        menuDisplay = MenuDisplay.MainMenu;
    }

    public void LoadMainMenuLevelSelectScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        SetPortraitRotation();
        menuDisplay = MenuDisplay.LevelSelectMenu;
    }

    public void LoadLevelScene()
    {
        Debug.Log("Load LevelID: " + sceneId);
        Debug.Log("Load UnimogPrefab: " + unimogPrefabPath);

        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);   
        SetLandscapeOrientation();
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    public MenuDisplay GetMenuDisplay()
    {
        return menuDisplay;
    }
        
}

public enum MenuDisplay
{
    MainMenu, LevelSelectMenu
}
