using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayRating : MonoBehaviour {

    public Image star1;
    public Image star2;
    public Image star3;

    public void SetRating(float rating)
    {
        if(rating >= 10 && rating <= 20)
        {
            star1.gameObject.SetActive(true);
        }else if(rating > 20 && rating <= 30)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
        }
        else if(rating > 30)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
    }

}
