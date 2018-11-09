using UnityEngine;

public class IngameMenu : MonoBehaviour {

    private GameManager gm;

    public void LoadMenuScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadMenuScene();
    }

    public void RestartLevel()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevelScene();
    }
}
