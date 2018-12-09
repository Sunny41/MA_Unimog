using UnityEngine;
using UnityEngine.UI;

public class UnimogGalery : MonoBehaviour {

    private GaleryMenuDisplay galeryMenuDisplay;
    public Button button;
    public Image texture;

	public void Initialize(GaleryMenuDisplay gmd, int id, string texturePath)
    {
        this.galeryMenuDisplay = gmd;
        this.button.name = id.ToString();
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
