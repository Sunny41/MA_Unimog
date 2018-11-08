using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static bool created = false;
    private string unimogPrefabPath;
    private string sceneId;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        SetPortraitRotation();
    }

    private void SetPortraitRotation()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void SetLandscapeRightOrientation()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.LandscapeRight;
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

        SceneManager.LoadSceneAsync(sceneId);
        SetLandscapeRightOrientation();
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
