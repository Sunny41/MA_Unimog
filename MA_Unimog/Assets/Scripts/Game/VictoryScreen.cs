using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour {

    [SerializeField] private LevelDisplayRating levelDisplayRating;

    public void SetRating(float rating)
    {
        levelDisplayRating.SetRating(rating);
    }
}
