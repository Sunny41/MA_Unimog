using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CreditsMenu : MonoBehaviour {

    public Text creditText;
    private JsonData levelData;

    void Start () {
        levelData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/JSON/credits.json"));
        CreateCredits();
    }

    private void CreateCredits()
    {
        for (int i = 0; i < levelData.Count; i++)
        {
            string engine = (string)levelData[i]["engine"];
            string aboutUs = (string)levelData[i]["aboutUs"];
            string aboutGame = (string)levelData[i]["aboutGame"];
            string aboutMuseum = (string)levelData[i]["aboutMuseum"];


            string[] students = aboutUs.Split(';');
            creditText.supportRichText = true;
            creditText.text = engine + "\n\n"
                                    + students[0] + "\n"
                                    + students[1] + "\n"
                                    + students[2] + "\n"
                                    + students[3] + "\n\n"
                                    + aboutGame + "\n\n" 
                                    + aboutMuseum;
        }
    }
}
