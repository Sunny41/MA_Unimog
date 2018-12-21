using UnityEngine;

public class IngameMenu : MonoBehaviour {

    private GameManager gm;
    [SerializeField] private UIStatusElement timeTxt;
    [SerializeField] private UIStatusElement boxTxt;
    [SerializeField] private UIStatusElement fuelTxt;
    [SerializeField] private GameObject ingameMenuDisplay;

    public void ShowIngameMenu()
    {
        ingameMenuDisplay.SetActive(true);
    }

    public void HideIngameMenu()
    {
        ingameMenuDisplay.SetActive(false);
    }

    public void SetTime(int time)
    {
        timeTxt.SetText("" + time + "s");
    }

    public void SetBoxAmount(int amount)
    {
        boxTxt.SetText("" + amount);
    }

    public void SetFuel(float fuel)
    {
        fuelTxt.SetText("" + fuel + "l");
    }

    public void LoadMenuScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadMenuScene();
    }

    public void RestartLevel()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevelScene();
    }
}
