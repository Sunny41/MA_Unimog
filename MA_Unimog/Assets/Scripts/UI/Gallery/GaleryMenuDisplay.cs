using UnityEngine;
using LitJson;

public class GaleryMenuDisplay : MonoBehaviour {

    [SerializeField] private GaleryDetailMenu galeryDetailMenu;
    private JsonData unimogData;
    public GameObject scrollbar;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        unimogData = JsonMapper.ToObject(jsonFile.text);
        CreateUnimogDisplay();
        
        //Deactivate menu-obj
        gameObject.SetActive(false);
    }

    void CreateUnimogDisplay()
    {
        for (int i = 0; i < unimogData.Count; i++)
        {
            GameObject unimogGalery = (GameObject)Resources.Load("Prefabs/UI/UnimogGalery");
            if (unimogGalery != null)
            {
                int unimogID = (int) unimogData[i]["id"];
                string spritePath = "Gallery/" + (string)unimogData[i]["sprite"];
                string unimogName = (string)unimogData[i]["nomenclature"]["modelSeries"];
                GameObject obj = (GameObject)Instantiate(unimogGalery, scrollbar.transform);
                obj.GetComponent<UnimogGalery>().Initialize(this, unimogID, spritePath, unimogName);
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }
    }
    
    public void OpenUnimogDetailMenu(int unimogId)
    {
        galeryDetailMenu.gameObject.SetActive(true);
        galeryDetailMenu.Initialize(unimogId);
        gameObject.SetActive(false);
    }
}
