using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Joystick joystick;

    public float driveSpeed = 40f;

    float horizontalMove = 0f;


    void Update()
    {

        //horizontalMove = Input.GetAxisRaw("Horizontal") * driveSpeed;
        horizontalMove = joystick.Horizontal * driveSpeed;

        //Debug.Log(horizontalMove);

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}