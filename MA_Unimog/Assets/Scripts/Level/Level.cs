using LitJson;
using System.Collections.Generic;
using UnityEngine;

public class Level {

    private int id;
    private string sceneId;
    private string level;
    private int? nextLevel;
    private int time;
    private int unimogBoxes;
    private int? unlockUnimogId;

	public Level(string sceneId)
    {
        this.sceneId = sceneId;

        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        JsonData levelData = JsonMapper.ToObject(jsonFile.text);

        for (int i = 0; i < levelData.Count; i++)
        {
            if (levelData[i]["sceneId"].ToString() == sceneId)
            {
                id = (int)levelData[i]["id"];
                level = (string)levelData[i]["level"];
                nextLevel = (int?)levelData[i]["nextLevelId"];
                time = (int)levelData[i]["time"];
                unimogBoxes = (int)levelData[i]["unimogBoxes"];
                ICollection<string> keys = (ICollection<string>)levelData[i].Keys;
                unlockUnimogId = null;
                foreach(string key in keys)
                {
                    if (key.Equals("unlockUnimogId"))
                    {
                        unlockUnimogId = (int)levelData[i]["unlockUnimogId"];
                    }
                }
            }
        }
    }

    public Level(int levelId)
    {
        this.id = levelId;

        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/levels") as TextAsset;
        JsonData levelData = JsonMapper.ToObject(jsonFile.text);

        for (int i = 0; i < levelData.Count; i++)
        {
            if ((int)levelData[i]["id"] == id)
            {
                sceneId = (string)levelData[i]["sceneId"];
                level = (string)levelData[i]["level"];
                nextLevel = (int?)levelData[i]["nextLevelId"];
                time = (int)levelData[i]["time"];
                unimogBoxes = (int)levelData[i]["unimogBoxes"];
            }
        }
    }

    public int GetId()
    {
        return id;
    }

    public string GetSceneId()
    {
        return sceneId;
    }

    public string GetLevel()
    {
        return level;
    }

    public int GetLevelTime()
    {
        return time;
    }

    public int GetUnimogBoxes()
    {
        return unimogBoxes;
    }

    public Level NextLevel()
    {
        if(nextLevel != null)
        {
            return new Level((int)nextLevel);
        }
        return null;
    }

    public int? GetUnlockUnimogId()
    {
        return unlockUnimogId;
    }
}
