using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Joystick driveJoystick;
    public Joystick tiltJoystick;

    public Animator frontWheelAnimator;
    public Animator backWheelAnimator;

    public float driveSpeed = 40f;
    public float tiltAmount = 5f;

    float horizontalMove = 0f;
    float tilt = 0f;


    void Update()
    {


        horizontalMove = driveJoystick.Horizontal * driveSpeed;

        //Debug.Log(horizontalMove);
        if (horizontalMove == 0){
            frontWheelAnimator.SetTrigger("idle");
            backWheelAnimator.SetTrigger("idle");
        }
        else{
            frontWheelAnimator.SetTrigger("driving");
            backWheelAnimator.SetTrigger("driving");
        }

        tilt = tiltJoystick.Horizontal * tiltAmount;

        if(tilt > 0){
            Debug.Log(tilt);
        }




    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        controller.transform.localScale = new Vector3(1, 1, 1);

        controller.Tilt(tilt * Time.fixedDeltaTime);
    }
}