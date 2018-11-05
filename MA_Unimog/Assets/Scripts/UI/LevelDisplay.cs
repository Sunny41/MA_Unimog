using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

    public Button button;
    public Text text;

	public void Initialize(int levelID, int level)
    {
        button.name = levelID.ToString();
        text.text = level.ToString();
    }

    public void SelectLevel()
    {
        Debug.Log("LEVEL " + button.name + " SELECTED");
    }
}
