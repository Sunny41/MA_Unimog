using UnityEngine;
using LitJson;
using System.Collections.Generic;

public class UnimogSelectMenu : MonoBehaviour {

    private GameManager gm;

    private List<UnimogDisplay> unimogDisplayList;
    private JsonData unimogData;
    public GameObject scrollbar;
    public GameObject LevelSelectMenu;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        unimogData = JsonMapper.ToObject(jsonFile.text);
        unimogDisplayList = new List<UnimogDisplay>();
        CreateUnimogDisplay();
        CheckUnimogsUnlocked();

        //Deactivate menu-obj
        gameObject.SetActive(false);
    }

    void CreateUnimogDisplay()
    {
        for (int i = 0; i < unimogData.Count; i++)
        {
            GameObject unimogDisplay = (GameObject) Resources.Load("Prefabs/UI/UnimogDisplay");
            if(unimogDisplay != null)
            {
                int unimogID = (int)unimogData[i]["id"];
                string spritePath = "Gallery/" + (string)unimogData[i]["sprite"];
                string unimogName = (string)unimogData[i]["nomenclature"]["modelSeries"];
                int speed = (int)unimogData[i]["maxSpeed"];
                int acceleration = (int)unimogData[i]["acceleration"];
                int fuel = (int)unimogData[i]["fuel"];
                int wheight = (int)unimogData[i]["wheight"];
                string prefabPath = (string)unimogData[i]["prefab"];
                GameObject obj = (GameObject)Instantiate(unimogDisplay, scrollbar.transform);
                obj.GetComponent<UnimogDisplay>().Initialize(this, unimogID, prefabPath, spritePath, unimogName, speed, acceleration, fuel, wheight);
                unimogDisplayList.Add(obj.GetComponent<UnimogDisplay>());
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }
            
        }
    }

    private void CheckUnimogsUnlocked()
    {
        JsonData unlockedUnimogData = GameObject.Find("GameManager").GetComponent<GameManager>().GetUnlockedUnimogData();
        if (unlockedUnimogData != null)
        {
            for (int i = 0; i < unlockedUnimogData.Count; i++)
            {
                foreach (UnimogDisplay unimogDisplay in unimogDisplayList)
                {
                    if ((int)unlockedUnimogData[i]["unimogId"] == unimogDisplay.GetUnimogId())
                    {
                        unimogDisplay.UnlockUnimog();
                    } 
                }
            }
        }
    }

    public void UnimogSelected(string prefabPath)
    {
        gm.SetUnimogPrefabPath(prefabPath);
        gm.LoadLevelScene();
    }

}
