using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    private string unimogPrefabPath;
    private string sceneId;

    //Singleton
    public static GameManager instance;

    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(this.gameObject);
            SetPortraitRotation();
        }
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
