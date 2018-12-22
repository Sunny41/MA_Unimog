using LitJson;
using UnityEngine;

public class Level {

    private int id;
    private string sceneId;
    private int level;
    private int? nextLevel;
    private int time;
    private int unimogBoxes;

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
                level = (int)levelData[i]["level"];
                nextLevel = (int?)levelData[i]["nextLevelId"];
                time = (int)levelData[i]["time"];
                unimogBoxes = (int)levelData[i]["unimogBoxes"];
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
                level = (int)levelData[i]["level"];
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

    public int GetLevel()
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
}
