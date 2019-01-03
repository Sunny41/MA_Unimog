using UnityEngine;
using LitJson;
using System.Collections.Generic;

public class GaleryMenuDisplay : MonoBehaviour {

    [SerializeField] private GaleryDetailMenu galeryDetailMenu;
    private JsonData unimogData;
    private List<UnimogGalery> unimogGaleryList;
    public GameObject scrollbar;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        unimogData = JsonMapper.ToObject(jsonFile.text);
        unimogGaleryList = new List<UnimogGalery>();
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
                unimogGaleryList.Add(obj.GetComponent<UnimogGalery>());
            }
            else
            {
                Debug.Log("Cannot load resource!");
            }

        }

        CheckUnlockedGalery();
    }

    private void CheckUnlockedGalery()
    {
        JsonData unlockedUnimogData = GameObject.Find("GameManager").GetComponent<GameManager>().GetUnlockedUnimogData();
        if (unlockedUnimogData != null)
        {
            for (int i = 0; i < unlockedUnimogData.Count; i++)
            {
                foreach (UnimogGalery unimogGalery in unimogGaleryList)
                {
                    if ((int)unlockedUnimogData[i]["unimogId"] == unimogGalery.GetUnimogId())
                    {
                        unimogGalery.UnlockGalery();
                    }
                }
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
