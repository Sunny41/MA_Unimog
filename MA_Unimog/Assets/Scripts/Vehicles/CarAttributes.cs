using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarAttributes : MonoBehaviour
{

    public Transform cargoCheck;
    public LayerMask whatIsBox;
    public float fuel = 500f;

    [SerializeField]
    private float fuelConsumption = 10f;

    private bool canDrive = false;
    private bool tippedOver = false;
    private int boxes = 0;

    private InitializeCar ic;
    private UnityAction deactivateUserInputListener;
    private UnityAction activateUserInputListener;

    void Start()
    {
        ic = new InitializeCar();
        deactivateUserInputListener = new UnityAction(DeactivateCanDriveStatus);
        activateUserInputListener = new UnityAction(ActivateCanDriveStatus);

        EventListener.StartListening("DeactivatePlayerInputEvent", deactivateUserInputListener);
        EventListener.StartListening("ActivatePlayerInputEvent", activateUserInputListener);
    }

    private class InitializeCar : MonoBehaviour
    {
        public int boxes = 0;
        public void SetBoxesAmount(int boxes)
        {
            this.boxes = boxes;
        }

        public int GetBoxesAmount()
        {
            return this.boxes;
        }
    }

    void DeactivateCanDriveStatus()
    {
        SetCanDriveStatus(false);
    }

    void ActivateCanDriveStatus()
    {
        SetCanDriveStatus(true);
    }


    public bool SetBoxesAmount(int boxes) //nach dem ersten setzen der Boxen ungültig!
    {
        if (this.ic != null)
        {
            this.ic.SetBoxesAmount(boxes);
            Destroy(ic);
            return true;
        }
        return false;
    }

    public bool GetCanDriveStatus()
    {
        return this.canDrive;
    }

    public void SetCanDriveStatus(bool status)
    {
        this.canDrive = status;
    }

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

    public void ConsumeFuel()
    {
        this.fuel -= fuelConsumption;

        if (this.fuel <= 0)
        {
            this.SetCanDriveStatus(false);
        }
    }

    public void SetTippedOver(bool value)
    {
        this.tippedOver = value;
    }

    public bool TippedOver()
    {
        return tippedOver;
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
