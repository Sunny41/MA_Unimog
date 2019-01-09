using UnityEngine;
using Cinemachine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CarController : MonoBehaviour
{
    public bool useTouchinput = false;

    public Transform groundCheck;
    public Transform ceilingCheck;

    public LayerMask whatIsGround;

    public float driveSpeed = 2000f;

    public float rotationSpeed = 500f;
    public float torque = 4f;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    private JointMotor2D motor;

    public Rigidbody2D rb;

    private Joystick joystick;
    private CinemachineVirtualCamera CMcam;

    private CarAttributes carAttributes;

    private bool grounded;
    private const float groundedRadius = .2f;

    private bool tippedOver = false;

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
        this.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = torque };

        //CarAttributes
        this.carAttributes = GetComponent<CarAttributes>();
    }
    void Update()
    {
        if (!useTouchinput)
        {
            /**
            * Tastaturinputs    
            */
            movement = -Input.GetAxis("Horizontal");
            // rotation = Input.GetAxisRaw("Vertical");
            rotation = CrossPlatformInputManager.GetAxis("Vertical");
        }
        else
        {
            /**
            * Mobileinputs 
            */
            movement = -this.joystick.Horizontal;
            rotation = CrossPlatformInputManager.GetAxis("Vertical");
        }




        /**
        * Camera Zoom Conditions
        */
        if (!grounded && tippedOver == false)
        {
            StartCoroutine("CameraZoom", "ZOOM_OUT");
        }
        else if ((grounded || tippedOver) && CMcam.m_Lens.OrthographicSize != 2.25f)
        {
            StartCoroutine("CameraZoom", "ZOOM_IN");
        }

    }

    private IEnumerator CameraZoom(string zoom)
    {
        if (zoom.Equals("ZOOM_OUT"))
        {
            while (CMcam.m_Lens.OrthographicSize < (2.25f + Mathf.Abs(this.motor.motorSpeed / 1000)))
            {
                yield return CMcam.m_Lens.OrthographicSize += 0.0005f;
            }
        }
        if (zoom.Equals("ZOOM_IN"))
        {
            while (CMcam.m_Lens.OrthographicSize > 2.25f)
            {
                yield return CMcam.m_Lens.OrthographicSize -= 0.01f;
            }
        }

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
                ca.SetTippedOver(tippedOver);
            }

        }
        else
        {
            gameOverCounter = 0;

            if (movement == 0f || tippedOver || !carAttributes.GetCanDriveStatus())
            {
                backWheel.useMotor = false;
                frontWheel.useMotor = false;
            }
            else if (grounded && !tippedOver && carAttributes.GetCanDriveStatus())
            {
                backWheel.useMotor = true;
                frontWheel.useMotor = true;

                this.motor.motorSpeed = movement * driveSpeed;
                backWheel.motor = motor;
                frontWheel.motor = motor;

                carAttributes.ConsumeFuel();
            }

            rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
        }

    }

}
