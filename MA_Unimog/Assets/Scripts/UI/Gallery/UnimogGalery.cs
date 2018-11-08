using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnimogGalery : MonoBehaviour {

    public Button button;
    public Image texture;

	public void Initialize(int id, string texturePath)
    {
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
}
