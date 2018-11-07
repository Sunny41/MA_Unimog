using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

    public Image levelTexture;
    public Button button;
    public Text text;
    public LevelDisplayRating levelRating;

    private GameObject unimogSelectMenu;
    private LevelSelectMenu levelSelectMenu;
    [SerializeField]
    private bool locked;
    private string levelTexturePath;

    public void Initialize(LevelSelectMenu levelSelectMenu, GameObject unimogSelectMenu, int levelID, int level)
    {
        locked = true;
        //Set level texture
        Sprite lockedLevel = (Sprite)Resources.Load<Sprite>("Level/Schloss");
        levelTexture.sprite = lockedLevel;
        //Set level parameters
        this.levelSelectMenu = levelSelectMenu;
        this.unimogSelectMenu = unimogSelectMenu;
        button.name = levelID.ToString();
        text.text = level.ToString();
        levelRating.SetRating(0f);
    }

    public void SelectLevel()
    {
        if (!locked)
        {
            Debug.Log("LEVEL " + button.name + " SELECTED");
            levelSelectMenu.LevelSelected();
        }        
    }

    public void UnlockLevel()
    {
        Sprite levelSprite = Resources.Load<Sprite>(levelTexturePath);
        levelTexture.sprite = levelSprite;
        locked = false;
    }

    public void SetRating(float rating)
    {
        levelRating.SetRating(rating);
    }
}
