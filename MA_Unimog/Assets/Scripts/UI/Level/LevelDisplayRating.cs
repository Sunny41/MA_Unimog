using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayRating : MonoBehaviour {

    public Image star1;
    public Image star2;
    public Image star3;

    public void SetRating(float rating)
    {
        if(rating > 0 && rating <= 1)
        {
            star1.gameObject.SetActive(true);
        }else if(rating > 1 && rating <= 2)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
        }
        else if(rating > 2 && rating <= 3)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
    }

}
