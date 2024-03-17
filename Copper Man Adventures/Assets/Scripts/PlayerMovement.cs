using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Initially get the player limbs
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;

    // Reference to player limb motors
    private JointMotor2D rightThighMotorRef;
    private JointMotor2D leftThighMotorRef;

    // Set the speed the limbs move at
    public float hingeSpeed = 40;

    // Rocket boot force
    public float boostForce = 100f;

    //Rigid boy reference
    Rigidbody2D _rb;
    public bool obj1Done = false;
    public bool obj2Done = false;
    public bool obj3Done = false;

    //Animator
    public Animator animRight;
    public Animator animLeft;
    public bool isBoosting = false;

    //Obj 1
    // Balloon Image GameObject
    public GameObject ladyImage;
    // UI Image GameObject
    public GameObject obj1Image;

    //Obj 3
    // Balloon Image GameObject
    public GameObject balloonImage;
    // UI Image GameObject
    public GameObject obj3Image;

    // Start is called before the first frame update
    void Start()
    {
        balloonImage.SetActive(true);
        obj3Image.SetActive(true);
        // Set the motors to the limb motors
        rightThighMotorRef = rightThigh.motor;
        leftThighMotorRef = leftThigh.motor;

        //Set rigid body
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Right Thigh controls
        if (Input.GetKey(KeyCode.Q))
        {
            if (!PauseMenu.isPaused)
            {
                rightThigh.useMotor = true;
                rightThighMotorRef.motorSpeed = -hingeSpeed;
                rightThigh.motor = rightThighMotorRef;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (!PauseMenu.isPaused)
            {
                rightThigh.useMotor = true;
                rightThighMotorRef.motorSpeed = hingeSpeed;
                rightThigh.motor = rightThighMotorRef;
            }
        }
        else
        {
            rightThigh.useMotor = false;
        }

        // Left Thigh controls
        if (Input.GetKey(KeyCode.E))
        {
            if (!PauseMenu.isPaused)
            {
                leftThigh.useMotor = true;
                leftThighMotorRef.motorSpeed = -hingeSpeed;
                leftThigh.motor = leftThighMotorRef;
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (!PauseMenu.isPaused)
            {
                leftThigh.useMotor = true;
                leftThighMotorRef.motorSpeed = hingeSpeed;
                leftThigh.motor = leftThighMotorRef;
            }
        }
        else
        {
            leftThigh.useMotor = false;
        }

        // Rocket boots
        if (Input.GetKey(KeyCode.Space))
        {
            if (!PauseMenu.isPaused) { 
                // Get the direction opposite to the right thigh
                Vector2 boostDirection = new Vector2(-rightThigh.transform.right.x, -rightThigh.transform.right.y);

                // Apply the force
                GetComponent<Rigidbody2D>().AddForce(boostDirection * boostForce);
                isBoosting = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isBoosting = false;
        }

        if (isBoosting)
        {
            animRight.SetBool("boosting", true);
            animLeft.SetBool("boosting", true);
        }

        if (!isBoosting)
        {
            animRight.SetBool("boosting", false);
            animLeft.SetBool("boosting", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "lady")
        {
            obj1Done = true;
            ladyImage.SetActive(false);

        }

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Balloon")
        {
            obj3Done = true;
            balloonImage.SetActive(false);
            
        }

        if (obj1Done == true)
        {
            obj1Image.SetActive(false);
        }

        if (obj3Done == true)
        {
            obj3Image.SetActive(false);
        }
    }
}
