using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CarController : MonoBehaviour
{
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

    private bool tippedOver;
    const float ceilingRadius = .2f;

    private float movement = 0f;
    private float rotation = 0f;

    private float gameOverCounter = 0;

    void Update()
    {
        /**
         * Tastaturinputs    
         */
        // movement = -Input.GetAxis("Horizontal") * driveSpeed;
        // rotation = Input.GetAxisRaw("Vertical");

        /**
        * Mobileinputs 
        */
        // Joystick sollte über GameManager zugeteilt werden
        movement = -this.joystick.Horizontal * driveSpeed;
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

        // colliders = Physics2D.OverlapCircleAll(ceilingCheck.position, ceilingRadius, whatIsGround);
        // for (int i = 0; i < colliders.Length; i++)
        // {
        //     if (colliders[i].gameObject != gameObject)
        //         tippedOver = true;
        // }

        tippedOver = this.ceilingCheck.GetComponent<Collider2D>().IsTouchingLayers(whatIsGround);
        // Debug.Log("[CarController]: " + tippedOver);


        if (tippedOver)
        {
            gameOverCounter += Time.fixedDeltaTime;
            if (gameOverCounter >= 1f) //anzahl Sekunden an denen der Collider den Boden berühren soll
            {
                //das hier am besten an einer Zentralen Stelle im GameManager machen
                // -> z.B. GameManager.setGameOver()
                Time.timeScale = 0; //Spiel pausieren
                Debug.Log("[CarController]: GAME OVER!");
            }

        }
        else
        {
            gameOverCounter = 0;

            if (movement == 0f || tippedOver)
            {
                backWheel.useMotor = false;
                frontWheel.useMotor = false;
            }
            else if (grounded && !tippedOver)
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

}
