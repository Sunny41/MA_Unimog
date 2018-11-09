using UnityEngine;
using UnityEngine.UI;

public class UIStatusElement : MonoBehaviour {

    [SerializeField]
    protected Text statusText;

    public void SetText(string text)
    {
        statusText.text = text;
    }
}
