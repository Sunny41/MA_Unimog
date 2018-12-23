using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializeEvent : MonoBehaviour {
    
	void Start () {
        EventListener.TriggerEvent("InitializeGameEvent");
	}
}
