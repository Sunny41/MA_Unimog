using UnityEngine;
using LitJson;

public class UnimogSelectMenu : MonoBehaviour {

    private GameManager gm;

    private JsonData unimogData;
    public GameObject scrollbar;
    public GameObject LevelSelectMenu;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        unimogData = JsonMapper.ToObject(jsonFile.text);
        CreateUnimogDisplay();
    }

    void CreateUnimogDisplay()
    {
        for (int i = 0; i < unimogData.Count; i++)
        {
            GameObject unimogDisplay = (GameObject) Resources.Load("Prefabs/UI/UnimogDisplay");
            if(unimogDisplay != null)
            {
                int unimogID = int.Parse((string)unimogData[i]["id"]);
                string spritePath = "Gallery/" + (string)unimogData[i]["sprite"];
                string unimogName = (string)unimogData[i]["name"];
                int speed = int.Parse((string)unimogData[i]["maxSpeed"]);
                int acceleration = int.Parse((string)unimogData[i]["acceleration"]);
                int fuel = int.Parse((string)unimogData[i]["fuel"]);
                string prefabPath = (string)unimogData[i]["prefab"];
                GameObject obj = (GameObject)Instantiate(unimogDisplay, scrollbar.transform);
                obj.GetComponent<UnimogDisplay>().Initialize(this, unimogID, prefabPath, spritePath, unimogName, speed, acceleration, fuel);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }
            
        }
    }

    public void UnimogSelected(string prefabPath)
    {
        gm.SetUnimogPrefabPath(prefabPath);
        gm.LoadLevelScene();
    }

}
