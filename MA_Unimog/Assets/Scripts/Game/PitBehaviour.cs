using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CarAttributes ca = GameObject.Find("Player").GetComponentInChildren<CarAttributes>();
            ca.SetCanDriveStatus(false);
        }
    }
}
