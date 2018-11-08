using UnityEngine;

public class AdjustToScreenSize : MonoBehaviour {

    public bool adjustWidth;
    public bool adjustHeight;

	void Start () {
        if (adjustWidth)
        {
            RectTransform rt = GameObject.Find("Canvas").GetComponent<RectTransform>() as RectTransform;
            Vector2 size = rt.sizeDelta;

            float currentHeight = GetComponent<RectTransform>().sizeDelta.y;
            GetComponent<RectTransform>().sizeDelta = new Vector2(size.x, currentHeight);
        }

        if (adjustHeight)
        {
            int screenHeight = Screen.height;
            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, screenHeight);
        }
	}
}
