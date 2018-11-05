using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnimogDisplay : MonoBehaviour {

    public Button button;
    public Image texture;
    public Text unimogName;
    public Slider speedSlider;
    public Slider accelerationSlider;
    public Slider fuelSlider;

    public void Initialize(int id, string texturePath, string name, int speed, int acceleration, int fuel)
    {
        button.name = id.ToString();

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
    }

    public void DebugID()
    {
        Debug.Log("LOAD UNIMOG WITH ID: " + button.name);
    }
}
