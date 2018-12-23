using UnityEngine;

public class Finish : MonoBehaviour {

    [SerializeField] private Game game;
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            EventListener.TriggerEvent("VictoryEvent");
        }
    }
}
