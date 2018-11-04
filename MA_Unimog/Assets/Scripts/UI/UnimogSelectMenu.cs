using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class UnimogSelectMenu : MonoBehaviour {
    
    private JsonData unimogData;

    void Start()
    {
        unimogData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/JSON/unimogs.json"));
        ConstructItemDatabase();
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < unimogData.Count; i++)
        {
            Debug.Log((string)unimogData[i]["name"]);
        }
    }

}
