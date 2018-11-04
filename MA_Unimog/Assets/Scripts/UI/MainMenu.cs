using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject[] panels;

    private void Start()
    {
        InitializeMainMenu();   
    }
    

    private void InitializeMainMenu()
    {
        foreach(GameObject go in panels)
        {
            go.SetActive(false);
            if(go.name == "MainMenu")
            {
                go.SetActive(true);
            }
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
