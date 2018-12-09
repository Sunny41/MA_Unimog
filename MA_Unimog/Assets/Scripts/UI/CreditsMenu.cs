using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CreditsMenu : MonoBehaviour {

    public Text creditText;
    private JsonData creditsData;

    void Start () {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/credits") as TextAsset;
        creditsData = JsonMapper.ToObject(jsonFile.text);
        CreateCredits();

        //Deactivate menu-obj
        gameObject.SetActive(false);
    }

    private void CreateCredits()
    {
        for (int i = 0; i < creditsData.Count; i++)
        {
            string engine = (string)creditsData[i]["engine"];
            string aboutUs = (string)creditsData[i]["aboutUs"];
            string aboutGame = (string)creditsData[i]["aboutGame"];
            string aboutMuseum = (string)creditsData[i]["aboutMuseum"];


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
