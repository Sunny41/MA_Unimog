using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class CreditsMenu : MonoBehaviour {

    public Text engineTxt;
    public Text aboutUsTxt;
    public Text aboutGameTxt;
    public Text aboutMusuemTxt;
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
            string[] abouts = aboutMuseum.Split(';');
            string[] students = aboutUs.Split(';');

            engineTxt.supportRichText = true;
            engineTxt.text = engine;

            aboutUsTxt.supportRichText = true;
            for(int j=0; j<students.Length; j++)
            {
                aboutUsTxt.text += students[j] + "\n";
            }

            aboutGameTxt.supportRichText = true;
            aboutGameTxt.text = aboutGame;

            aboutMusuemTxt.supportRichText = true;
            for(int j=0; j<abouts.Length; j++)
            {
                aboutMusuemTxt.text += abouts[j] + "\n";
            }
        }
    }
}
