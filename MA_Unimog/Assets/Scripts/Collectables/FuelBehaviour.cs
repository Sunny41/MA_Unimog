using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehaviour : MonoBehaviour {

    public float fuelValue = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Debug.Log("FUEL COLLECTED"); //add fuelValue to fuelStatus

            Destroy(this.gameObject);
        }
    }
}
