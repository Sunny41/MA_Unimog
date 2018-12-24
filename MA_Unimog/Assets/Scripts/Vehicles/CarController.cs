using UnityEngine;
using Cinemachine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CarController : MonoBehaviour
{

    public Transform groundCheck;
    public Transform ceilingCheck;

    public LayerMask whatIsGround;

    public float driveSpeed = 2000f;

    public float rotationSpeed = 500f;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    private JointMotor2D motor;

    public Rigidbody2D rb;

    private Joystick joystick;
    private CinemachineVirtualCamera CMcam;

    private bool grounded;
    private const float groundedRadius = .2f;

    private bool tippedOver;

    private float movement = 0f;
    private float rotation = 0f;

    private float gameOverCounter = 0;


    void Start()
    {
        //Unimog registers itself to Camera
        CMcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        CMcam.m_Follow = this.transform;
        CMcam.m_LookAt = this.transform;

        //Unimog uses Joystick
        joystick = GameObject.Find("drive_joystick").GetComponent<FixedJoystick>();

        //Initialize Motor
        this.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 4f };
    }
    void Update()
    {
        /**
        * Tastaturinputs    
        */
        // movement = -Input.GetAxis("Horizontal");
        // rotation = Input.GetAxisRaw("Vertical");

        /**
        * Mobileinputs 
        */

        movement = -this.joystick.Horizontal;
        rotation = CrossPlatformInputManager.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        tippedOver = false;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
        tippedOver = this.ceilingCheck.GetComponent<Collider2D>().IsTouchingLayers(whatIsGround);


        if (tippedOver)
        {
            gameOverCounter += Time.fixedDeltaTime;
            if (gameOverCounter >= 1f) //anzahl Sekunden, die der Collider den Boden berühren soll
            {
                CarAttributes ca = this.GetComponentInParent<CarAttributes>();
                ca.SetCanDriveStatus(false);
            }

        }
        else
        {
            gameOverCounter = 0;
            CarAttributes ca = this.GetComponentInParent<CarAttributes>();

            if (movement == 0f || tippedOver || !ca.GetCanDriveStatus())
            {
                backWheel.useMotor = false;
                frontWheel.useMotor = false;
            }
            else if (grounded && !tippedOver && ca.GetCanDriveStatus())
            {
                backWheel.useMotor = true;
                frontWheel.useMotor = true;

                this.motor.motorSpeed = movement * driveSpeed;
                backWheel.motor = motor;
                frontWheel.motor = motor;

                ca.ConsumeFuel();
            }

            rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
        }

    }

}
