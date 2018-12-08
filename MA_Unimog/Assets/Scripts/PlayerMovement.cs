using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Joystick joystick;

    public Animator frontWheelAnimator;
    public Animator backWheelAnimator;

    public float driveSpeed = 40f;

    float horizontalMove = 0f;


    void Update()
    {


        horizontalMove = joystick.Horizontal * driveSpeed;

        Debug.Log(horizontalMove);
        if (horizontalMove == 0){
            frontWheelAnimator.SetTrigger("idle");
            backWheelAnimator.SetTrigger("idle");
        }
        else{
            frontWheelAnimator.SetTrigger("driving");
            backWheelAnimator.SetTrigger("driving");
        }


    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        controller.transform.localScale = new Vector3(1, 1, 1);
    }
}