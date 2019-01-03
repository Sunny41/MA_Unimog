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

    private Sprite unimogSprite;
    private int id;
    private string prefabPath;
    private bool locked;
    private string name;
    private int speed;
    private int acceleration;
    private int fuel;
    private int wheight;

    public void Initialize(UnimogSelectMenu unimogSelectMenu, int id, string prefabPath, string texturePath, string name, int speed, int acceleration, int fuel, int wheight)
    {
        this.locked = true;
        this.unimogSelectMenu = unimogSelectMenu;
        this.id = id;
        this.prefabPath = prefabPath;
        this.name = name;
        this.speed = speed;
        this.acceleration = acceleration;
        this.fuel = fuel;
        this.wheight = wheight;

        //Load the image
        Sprite lockedUnimog = (Sprite)Resources.Load<Sprite>("Textures/Schloss");
        this.texture.sprite = lockedUnimog;
        unimogSprite = Resources.Load<Sprite>(texturePath);

        unimogName.text = "";

        //Set speed
        speedSlider.minValue = 0;
        speedSlider.maxValue = 10;
        speedSlider.value = 0;

        //Set acceleration
        accelerationSlider.minValue = 0;
        accelerationSlider.maxValue = 10;
        accelerationSlider.value = 0;

        //Set fuel
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = 10;
        fuelSlider.value = 0;

        //Set wheight
        wheightSlider.minValue = 0;
        wheightSlider.maxValue = 10;
        wheightSlider.value = 0;
    }

    public void UnlockUnimog()
    {
        this.locked = false;
        this.texture.sprite = unimogSprite;

        unimogName.text = name;
        speedSlider.value = speed;
        accelerationSlider.value = acceleration;
        fuelSlider.value = fuel;
        wheightSlider.value = wheight;
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
