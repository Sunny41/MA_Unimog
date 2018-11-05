using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

    public Button button;
    public Text text;
    private GameObject unimogSelectMenu;
    private LevelSelectMenu levelSelectMenu;

    public void Initialize(LevelSelectMenu levelSelectMenu, GameObject unimogSelectMenu, int levelID, int level)
    {
        this.levelSelectMenu = levelSelectMenu;
        this.unimogSelectMenu = unimogSelectMenu;
        button.name = levelID.ToString();
        text.text = level.ToString();
    }

    public void SelectLevel()
    {
        Debug.Log("LEVEL " + button.name + " SELECTED");
        levelSelectMenu.LevelSelected();
    }
}
