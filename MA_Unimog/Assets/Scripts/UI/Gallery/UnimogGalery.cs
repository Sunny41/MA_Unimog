using UnityEngine;
using UnityEngine.UI;

public class UnimogGalery : Display
{

    private GaleryMenuDisplay galeryMenuDisplay;
    public Button button;
    [SerializeField] private Image texture;
    [SerializeField] private Text nameTxt;
    private bool locked;
    private Sprite galeryTexture;
    private int unimogId;
    private string unimogName;

    public void Initialize(GaleryMenuDisplay gmd, int id, string texturePath, string unimogName)
    {
        this.locked = true;
        this.unimogId = id;
        this.galeryMenuDisplay = gmd;
        this.button.name = id.ToString();
        this.unimogName = unimogName;
        this.nameTxt.text = "";
        Sprite lockedLevel = (Sprite)Resources.Load<Sprite>("Textures/Schloss");
        galeryTexture = Resources.Load<Sprite>(texturePath);
        this.texture.sprite = lockedLevel;        
    }

    public void UnlockGalery()
    {
        this.locked = false;
        this.texture.sprite = galeryTexture;
        nameTxt.text = unimogName;
    }

    public void SelectUnimog()
    {
        if (!locked)
        {
            int unimogId = int.Parse(button.name);
            galeryMenuDisplay.OpenUnimogDetailMenu(unimogId);
        }        
    }

    public int GetUnimogId()
    {
        return unimogId;
    }
}
