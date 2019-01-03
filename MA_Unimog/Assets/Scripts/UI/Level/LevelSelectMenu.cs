﻿using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class LevelSelectMenu : MonoBehaviour {

    private GameManager gm;

    private JsonData levelData;
    public GameObject scrollbar;
    public GameObject unimogSelectMenu;

    private List<GameObject> levelDisplayList;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        levelDisplayList = new List<GameObject>();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        levelData = JsonMapper.ToObject(jsonFile.text);
        CreateLevelDisplay();
        CheckLevelUnlocked();

        //Deactivate menu-obj
        gameObject.SetActive(false);
    }    

    void CreateLevelDisplay()
    {
        for (int i = 0; i < levelData.Count; i++)
        {
            GameObject levelDisplay = (GameObject)Resources.Load("Prefabs/UI/LevelDisplay");
            if (levelDisplay != null)
            {
                int levelID = (int)levelData[i]["id"];
                string level = (string)levelData[i]["level"];
                string sceneId = (string)levelData[i]["sceneId"];
                                
                GameObject obj = (GameObject)Instantiate(levelDisplay, scrollbar.transform);
                obj.GetComponent<LevelDisplay>().Initialize(this, unimogSelectMenu, levelID, sceneId, level);
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
        JsonData unlockedLevelData = GameObject.Find("GameManager").GetComponent<GameManager>().GetUnlockedLevelData();
        if (unlockedLevelData != null)
        {
            for(int i=0; i<unlockedLevelData.Count; i++)
            {
                foreach (GameObject obj in levelDisplayList)
                {
                    if((int)unlockedLevelData[i]["levelId"] == obj.GetComponent<LevelDisplay>().GetLevelId())
                    {
                        obj.GetComponent<LevelDisplay>().UnlockLevel();
                        float rating = (float)(double)unlockedLevelData[i]["rating"];
                        obj.GetComponent<LevelDisplay>().SetRating(rating);
                    }
                }
            }
        }
    }

    public void LevelSelected(string sceneId)
    {
        gameObject.SetActive(false);

        if (sceneId == "Lvl_test")
        {
            gm.SetUnimogPrefabPath("Baureihe_2010");
            gm.SetSceneId(sceneId);
            gm.LoadLevel(sceneId);
        }
        else
        {
            gm.SetSceneId(sceneId);
            unimogSelectMenu.SetActive(true);
        }        
    }
}
