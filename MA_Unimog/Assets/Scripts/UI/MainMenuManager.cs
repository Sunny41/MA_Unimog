using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    //Singleton
    public static MainMenuManager instance;

	void Start () {
		if(!instance)
        {
            DontDestroyOnLoad(this.gameObject);
        }
	}
}
