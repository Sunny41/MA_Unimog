using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CarController : MonoBehaviour {

    public Joystick joystick;

    public Transform groundCheck;
    public Transform ceilingCheck;

    public LayerMask whatIsGround;

    public float driveSpeed = 1500f;
	public float rotationSpeed = 500f;

	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;

	public Rigidbody2D rb;

    private bool grounded;
    const float groundedRadius = .2f;
    const float ceilingRadius = .2f;

    private float movement = 0f;
	private float rotation = 0f;

	void Update ()
	{
        /**
         * Tastaturinputs    
         */       
        //movement = -Input.GetAxis("Horizontal") * driveSpeed;
        //rotation = Input.GetAxisRaw("Vertical"); 

        /**
        * Mobileinputs
        */
        movement = -joystick.Horizontal * driveSpeed;
        rotation = CrossPlatformInputManager.GetAxis("Vertical");

    }

	void FixedUpdate ()
	{
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
                grounded = true;
        }

        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else if(grounded)
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }

}
