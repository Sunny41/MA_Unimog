using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class LevelSelectMenu : MonoBehaviour {

    private JsonData levelData;
    public GameObject scrollbar;

    void Start()
    {
        levelData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/JSON/levels.json"));
        CreateLevelDisplay();
    }

    void CreateLevelDisplay()
    {
        for (int i = 0; i < levelData.Count; i++)
        {
            GameObject levelDisplay = (GameObject)Resources.Load("Prefabs/UI/LevelDisplay");
            if (levelDisplay != null)
            {
                int levelID = (int)levelData[i]["id"];
                int level = (int)levelData[i]["level"];

                levelDisplay.GetComponent<LevelDisplay>().Initialize(levelID, level);
                Instantiate(levelDisplay, scrollbar.transform);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }
    }

    
}
