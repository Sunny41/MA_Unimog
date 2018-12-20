using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttributes : MonoBehaviour {

    public Transform cargoCheck;
    public LayerMask whatIsBox;
    public float fuel = 500f;

    private int boxes = 0;


    public float GetFuelStatus(){
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

    private void FixedUpdate()
    {

        //Debug.Log(GameObject.FindGameObjectsWithTag("boxes"));
        GameObject[] boxesOnCar = GameObject.FindGameObjectsWithTag("boxes");

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
        Debug.Log(GetBoxesAmount());
    }
}
