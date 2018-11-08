using UnityEngine;
using LitJson;

public class GaleryMenuDisplay : MonoBehaviour {

    private JsonData unimogData;
    public GameObject scrollbar;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        unimogData = JsonMapper.ToObject(jsonFile.text);
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
                int speed = (int)unimogData[i]["maxSpeed"];
                int acceleration = (int)unimogData[i]["acceleration"];
                int fuel = (int)unimogData[i]["fuel"];
                int wheight = (int)unimogData[i]["wheight"];
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
