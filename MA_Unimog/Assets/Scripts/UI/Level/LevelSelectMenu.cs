using System.Collections.Generic;
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
                int level = (int)levelData[i]["level"];
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
        int testCount = 0;
        foreach(GameObject obj in levelDisplayList)
        {
            testCount++;
            if(testCount <= 2)
            {
                obj.GetComponent<LevelDisplay>().UnlockLevel();
                obj.GetComponent<LevelDisplay>().SetRating(1.8f);
            }
            
        }
    }

    public void LevelSelected(string sceneId)
    {
        gameObject.SetActive(false);
        unimogSelectMenu.SetActive(true);
        gm.SetSceneId(sceneId);
    }
}
