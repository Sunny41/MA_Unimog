using LitJson;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    private string unimogPrefabPath;
    private string sceneId;
    private MenuDisplay menuDisplay;

    private JsonData unlockedLevelData;
    private JsonData unlockedUnimogData;

    [SerializeField] private MainMenu mainMenu;

    //Singleton
    public static GameManager instance;

    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(this.gameObject);
            //SetPortraitRotation();
        }

        //Load unlocked
        LoadUnlocked();

        //activate all menus. They deactivate them self after theri initialisation
        menuDisplay = MenuDisplay.MainMenu;
        mainMenu.InitializeMainMenu();
    }

    private void LoadUnlocked()
    {
        //Load unlocked level
        string unlockedLevelString = PlayerPrefs.GetString("unlocked_level");
        if(unlockedLevelString != null && !unlockedLevelString.Equals(""))
        {
            unlockedLevelData = JsonMapper.ToObject(unlockedLevelString);
        }
        else
        {
            //No unlocked level. Unlock tutorial level
            PlayerPrefs.SetString("unlocked_level", "[{'levelId':1, 'rating':0.0}]");
            LoadUnlocked();
        }

        //Load unlocked unimogs
        string unlockedUnimogString = PlayerPrefs.GetString("unlocked_unimogs");
        if(unlockedUnimogString != null && !unlockedUnimogString.Equals(""))
        {
            unlockedUnimogData = JsonMapper.ToObject(unlockedUnimogString);
        }
        else
        {
            //No unlocked unimog. unlock the first unimog
            Debug.Log("NO UNLOCKED UNIMOGS");
            PlayerPrefs.SetString("unlocked_unimogs", "[{'unimogId':1}]");
            LoadUnlocked();
        }
    }

    private void SaveUnlocked()
    {
        PlayerPrefs.SetString("unlocked_level", unlockedLevelData.ToJson());
        PlayerPrefs.SetString("unlocked_unimogs", unlockedUnimogData.ToJson());
        PlayerPrefs.Save();
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

    private void SetAllOrientations()
    {
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
    }

    public void UnlockLevel(Level level, float rating)
    {
        //Save rating from current level
        for(int i=0; i<unlockedLevelData.Count; i++)
        {
            if((int)unlockedLevelData[i]["levelId"] == level.GetId())
            {
                unlockedLevelData[i]["rating"] = rating;
            }
        }

        //Unlock next level if possible
        if(level.NextLevel() != null)
        {
            JsonData newLevel = new JsonData();
            newLevel["levelId"] = level.NextLevel().GetId();
            newLevel["rating"] = 0.0f;
            unlockedLevelData.Add(newLevel);
        }

        //Unlock unimog if possible
        if(level.GetUnlockUnimogId() != null)
        {
            JsonData newUnimog = new JsonData();
            newUnimog["unimogId"] = (int)level.GetUnlockUnimogId();
            unlockedUnimogData.Add(newUnimog);
        }

        SaveUnlocked();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        //SetPortraitRotation();
        SetAllOrientations();
        menuDisplay = MenuDisplay.MainMenu;
    }

    public void LoadMainMenuLevelSelectScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        //SetPortraitRotation();
        SetAllOrientations();
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

    public JsonData GetUnlockedLevelData()
    {
        return unlockedLevelData;
    }

    public JsonData GetUnlockedUnimogData()
    {
        return unlockedUnimogData;
    }
        
}

public enum MenuDisplay
{
    MainMenu, LevelSelectMenu
}
