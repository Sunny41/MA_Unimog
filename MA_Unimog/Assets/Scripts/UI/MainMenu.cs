using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject unimogSelectMenu;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject galerieMenu;

    void Start()
    {
        MenuDisplay menuDisplay = GameObject.Find("GameManager").GetComponent<GameManager>().GetMenuDisplay();

        InitializeMainMenu();

        switch (menuDisplay)
        {
            case MenuDisplay.MainMenu:
                ShowMainMenu();
                break;
            case MenuDisplay.LevelSelectMenu:
                ShowLevelSelectMenu();
                break;
        }
    }

    public void QuitApplication()
    {
        GameObject.Find("SettingsManager").GetComponent<SettingsManager>().SaveSettings();
        Application.Quit();
    }

    public void InitializeMainMenu()
    {
        mainMenu.SetActive(true);
        unimogSelectMenu.SetActive(true);
        levelSelectMenu.SetActive(true);
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(true);
        galerieMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        unimogSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        galerieMenu.SetActive(false);
    }

    public void ShowLevelSelectMenu()
    {
        mainMenu.SetActive(false);
        unimogSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        galerieMenu.SetActive(false);
    }
}
