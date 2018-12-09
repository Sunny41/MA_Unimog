using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class GaleryDetailMenu : MonoBehaviour {

    [SerializeField] private Image image;
    [SerializeField] private Text yearTxt;
    [SerializeField] private Text manufacturerTxt;
    [SerializeField] private Text typeTxt;
    [SerializeField] private Text modelSeriesTxt;
    [SerializeField] private Text salesDescriptionTxt;
    [SerializeField] private Text numberModelTxt;
    [SerializeField] private Text engineTxt;
    [SerializeField] private Text enginePowerTxt;
    [SerializeField] private Text capacityTxt;
    [SerializeField] private Text dimensionsTxt;
    [SerializeField] private Text wheelbaseTxt;
    [SerializeField] private Text maxWheightAllowedTxt;
    [SerializeField] private Text quantityTxt;

    public void Initialize(int unimogId)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/unimogs") as TextAsset;
        JsonData unimogData = JsonMapper.ToObject(jsonFile.text);

        string sprite = (string) unimogData[unimogId - 1]["nomenclature"]["sprite"];
        image.sprite = Resources.Load<Sprite>("Gallery/" + sprite);

        yearTxt.text = "" + (int)unimogData[unimogId - 1]["nomenclature"]["year"];
        manufacturerTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["manufacturer"];
        typeTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["type"];
        modelSeriesTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["modelSeries"];
        salesDescriptionTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["salesDescription"];
        numberModelTxt.text = "" + (int)unimogData[unimogId - 1]["nomenclature"]["numberModel"];
        engineTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["engine"];
        enginePowerTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["enginePower"];
        capacityTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["capacity"];
        dimensionsTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["dimension"];
        wheelbaseTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["wheelbase"];
        maxWheightAllowedTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["maxWheightAllowed"];
        quantityTxt.text = (string)unimogData[unimogId - 1]["nomenclature"]["quantity"];
    }
}
