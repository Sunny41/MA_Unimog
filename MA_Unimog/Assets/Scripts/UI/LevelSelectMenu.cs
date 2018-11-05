using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class LevelSelectMenu : MonoBehaviour {
    
    private JsonData levelData;
    public GameObject scrollbar;
    public GameObject unimogSelectMenu;

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
                                
                GameObject obj = (GameObject)Instantiate(levelDisplay, scrollbar.transform);
                obj.GetComponent<LevelDisplay>().Initialize(this, unimogSelectMenu, levelID, level);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }
    }

    public void LevelSelected()
    {
        gameObject.SetActive(false);
        unimogSelectMenu.SetActive(true);
    }
}
