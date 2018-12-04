using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public Text winscreen;

	// Use this for initialization
	void Start () {
        winscreen.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        winscreen.text = "Level geschaft \n Kisten: X von X \n Zeit: X \n Punkte: X ";
    }
}
