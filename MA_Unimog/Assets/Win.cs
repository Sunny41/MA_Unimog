using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public Text winscreen;
    public int maxBox;
    public static float time;


    // Use this for initialization
    void Start () {
        winscreen.text = "";
        maxBox = getMaxBoxes(); //later deplace withe function to get max 
        
    }
	
	// Update is called once per frame
	void Update () {

        

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        int points = calculatePoints();
        winscreen.text = "Level geschaft \n Kisten: X von "+ maxBox +"  \n Zeit: "+ Time.fixedTime + "  \n Punkte: "+ points ;
    }

    //later calculate Points
    private int calculatePoints()
    {

        return 3;
    }
    private int getMaxBoxes()
    {

        return 3;
    }
}
