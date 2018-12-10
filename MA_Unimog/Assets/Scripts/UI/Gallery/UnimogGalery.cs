using UnityEngine;
using UnityEngine.UI;

public class UnimogGalery : MonoBehaviour {

    private GaleryMenuDisplay galeryMenuDisplay;
    public Button button;
    [SerializeField] private Image texture;
    [SerializeField] private Text nameTxt;

	public void Initialize(GaleryMenuDisplay gmd, int id, string texturePath, string unimogName)
    {
        this.galeryMenuDisplay = gmd;
        this.button.name = id.ToString();
        nameTxt.text = unimogName;
        Sprite texture = Resources.Load<Sprite>(texturePath);
        if(texture != null)
        {
            this.texture.sprite = texture;
        }
        else
        {
            Debug.Log("Texture cannot be loaded!");
        }
        
    }

    public void SelectUnimog()
    {
        int unimogId = int.Parse(button.name);
        galeryMenuDisplay.OpenUnimogDetailMenu(unimogId);
    }
}
