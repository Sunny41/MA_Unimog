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
            if (collision.GetComponent<CarAttributes>() != null)
            {
                collision.GetComponent<CarAttributes>().AddFuel(this.fuelValue);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("item_fuel_collected");
                // Debug.Log("[FuelBehaviour]: " + collision.GetComponent<CarAttributes>().GetFuelStatus());
                Destroy(this.gameObject);
            }

        }
    }
}
