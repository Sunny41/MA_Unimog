using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttributes : MonoBehaviour
{

    public Transform cargoCheck;
    public LayerMask whatIsBox;
    public float fuel = 500f;
    public float fuelConsumption = 10f;

    private int boxes = 0;


    public float GetFuelStatus()
    {
        return this.fuel;
    }

    public void AddFuel(float fuelAmount)
    {
        this.fuel += fuelAmount;
    }

    public int GetBoxesAmount()
    {
        return this.boxes;
    }

    public void consumeFuel()
    {
        this.fuel -= fuelConsumption;
    }

    private void Update()
    {
        // Collider2D collider = this.GetComponentInChildren<Collider2D>();
        // if (collider.IsTouching(GameObject.FindGameObjectWithTag("Fuel").GetComponent<Collider2D>()))
        // {
        //     float fuelAmountToAdd = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelBehaviour>().fuelValue;
        //     // Debug.Log(fuelAmountToAdd);
        //     this.AddFuel(fuelAmountToAdd);
        //     Destroy(GameObject.FindGameObjectWithTag("Fuel"));
        // };
    }
    private void FixedUpdate()
    {
        GameObject[] boxesOnCar = GameObject.FindGameObjectsWithTag("Box");
        Collider2D collider = cargoCheck.GetComponentInParent<Collider2D>();

        int boxesTemp = 0;
        for (int i = 0; i < boxesOnCar.Length; i++)
        {
            if (collider.IsTouching(boxesOnCar[i].GetComponent<Collider2D>()))
            {
                boxesTemp++;
            }
        }
        this.boxes = boxesTemp;
        // Debug.Log([CarAttributes]: GetBoxesAmount());
    }
}
