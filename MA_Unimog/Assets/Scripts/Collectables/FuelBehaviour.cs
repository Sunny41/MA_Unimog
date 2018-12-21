using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehaviour : MonoBehaviour
{
    public float fuelValue = 100f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CarAttributes>().AddFuel(this.fuelValue);
            // Debug.Log("[FuelBehaviour]: " + collision.GetComponent<CarAttributes>().GetFuelStatus());
            Destroy(this.gameObject);
        }
    }
}
