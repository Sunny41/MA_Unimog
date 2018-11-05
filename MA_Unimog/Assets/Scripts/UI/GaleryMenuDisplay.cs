using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class GaleryMenuDisplay : MonoBehaviour {

    private JsonData unimogData;
    public GameObject scrollbar;

    void Start()
    {
        unimogData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/JSON/unimogs.json"));
        CreateUnimogDisplay();
    }

    void CreateUnimogDisplay()
    {
        for (int i = 0; i < unimogData.Count; i++)
        {
            GameObject unimogDisplay = (GameObject)Resources.Load("Prefabs/UI/UnimogGalery");
            if (unimogDisplay != null)
            {
                int unimogID = int.Parse((string)unimogData[i]["id"]);
                string spritePath = "Gallery/" + (string)unimogData[i]["sprite"];
                string unimogName = (string)unimogData[i]["name"];
                int speed = int.Parse((string)unimogData[i]["maxSpeed"]);
                int acceleration = int.Parse((string)unimogData[i]["acceleration"]);
                int fuel = int.Parse((string)unimogData[i]["fuel"]);
                GameObject obj = (GameObject)Instantiate(unimogDisplay, scrollbar.transform);
                obj.GetComponent<UnimogGalery>().Initialize(unimogID, spritePath);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }
    }
}
