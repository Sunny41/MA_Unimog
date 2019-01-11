using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : Display {

    public Image levelTexture;
    public Button button;
    public Text text;
    public LevelDisplayRating levelRating;

    private GameObject unimogSelectMenu;
    private LevelSelectMenu levelSelectMenu;
    [SerializeField]
    private bool locked;
    private string levelTexturePath;
    private Sprite levelSprite;
    private int levelId;
    private string sceneId;
    private string level;
    private float rating;

    public void Initialize(LevelSelectMenu levelSelectMenu, GameObject unimogSelectMenu, int levelID, string sceneId, string level)
    {
        locked = true;
        //Set level texture
        Sprite lockedLevel = (Sprite)Resources.Load<Sprite>("Textures/Schloss");
        levelTexture.sprite = lockedLevel;
        //Set level parameters
        levelSprite = Resources.Load<Sprite>(levelTexturePath);
        this.levelSelectMenu = levelSelectMenu;
        this.unimogSelectMenu = unimogSelectMenu;
        this.levelId = levelID;
        this.sceneId = sceneId;
        this.level = level;
        
        text.text = level.ToString();
    }

    public void SelectLevel()
    {
        if (!locked)
        {
            levelSelectMenu.LevelSelected(sceneId);
        }        
    }

    public void UnlockLevel()
    {
        levelTexture.sprite = levelSprite;
        locked = false;
    }

    public void SetRating(float rating)
    {
        levelRating.SetRating(rating);
    }

    public int GetLevelId()
    {
        return levelId;
    }
}
