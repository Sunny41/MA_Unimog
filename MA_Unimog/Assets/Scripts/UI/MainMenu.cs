using UnityEngine;

public class MainMenu : MonoBehaviour {
    
    public void QuitApplication()
    {
        GameObject.Find("SettingsManager").GetComponent<SettingsManager>().SaveSettings();
        Application.Quit();
    }
}
