using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour {

    private GameManager gm;

    public void LoadMenuScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadMenuScene();
    }
}
