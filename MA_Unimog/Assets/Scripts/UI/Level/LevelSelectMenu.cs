using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class LevelSelectMenu : MonoBehaviour {
    
    private JsonData levelData;
    public GameObject scrollbar;
    public GameObject unimogSelectMenu;

    private List<GameObject> levelDisplayList;

    void Start()
    {
        levelDisplayList = new List<GameObject>();
        levelData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/JSON/levels.json"));
        CreateLevelDisplay();
        CheckLevelUnlocked();
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
                levelDisplayList.Add(obj);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }
    }

    void CheckLevelUnlocked()
    {
        int testCount = 0;
        foreach(GameObject obj in levelDisplayList)
        {
            testCount++;
            if(testCount <= 1)
            {
                obj.GetComponent<LevelDisplay>().UnlockLevel();
                obj.GetComponent<LevelDisplay>().SetRating(1.8f);
            }
            
        }
    }

    public void LevelSelected()
    {
        gameObject.SetActive(false);
        unimogSelectMenu.SetActive(true);
    }
}
