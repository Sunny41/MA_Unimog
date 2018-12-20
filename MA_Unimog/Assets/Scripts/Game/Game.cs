using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private VictoryScreen victoryScreen;
    //[SerializedField] private GameOverScreen gameOverScreen;

	public void Start () {
        //Set Player to spawn point
        Vector2 position = new Vector2(spawn.position.x, spawn.position.y + 0.5f);
        player.transform.position = position;

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Load level informations
        string sceneId = gm.GetSceneId();
                
	}
	
	void Update () {
		
	}
}
