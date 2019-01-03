using UnityEngine;
using UnityEngine.UI;

public class UnimogDisplay : MonoBehaviour {

    private UnimogSelectMenu unimogSelectMenu;
    public Button button;
    public Image texture;
    public Text unimogName;
    public Slider speedSlider;
    public Slider accelerationSlider;
    public Slider fuelSlider;
    public Slider wheightSlider;

    private int id;
    private string prefabPath;
    private bool locked;

    public void Initialize(UnimogSelectMenu unimogSelectMenu, int id, string prefabPath, string texturePath, string name, int speed, int acceleration, int fuel, int wheight)
    {
        this.locked = true;
        this.unimogSelectMenu = unimogSelectMenu;
        this.id = id;
        this.prefabPath = prefabPath;

        //Load the image
        Sprite texture = Resources.Load<Sprite>(texturePath);
        if (texture != null)
        {
            this.texture.sprite = texture;
        }
        else
        {
            Debug.Log("Texture cannot be loaded!");
        }

        //Set name
        unimogName.text = name;

        //Set speed
        speedSlider.minValue = 0;
        speedSlider.maxValue = 10;
        speedSlider.value = speed;

        //Set acceleration
        accelerationSlider.minValue = 0;
        accelerationSlider.maxValue = 10;
        accelerationSlider.value = acceleration;

        //Set fuel
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = 10;
        fuelSlider.value = fuel;

        //Set wheight
        wheightSlider.minValue = 0;
        wheightSlider.maxValue = 10;
        wheightSlider.value = wheight;
    }

    public void UnlockUnimog()
    {
        this.locked = false;
    }

    public void SelectUnimog()
    {
        if(!locked)
        {
            unimogSelectMenu.UnimogSelected(prefabPath);
        }        
    }

    public int GetUnimogId()
    {
        return id;
    }
}
