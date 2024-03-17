using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Animator
    public Animator animRight;
    public Animator animLeft;
    public bool isBoosting = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the motors to the limb motors
        rightThighMotorRef = rightThigh.motor;
        leftThighMotorRef = leftThigh.motor;
    }

    // Update is called once per frame
    void Update()
    {
        // Right Thigh controls
        if (Input.GetKey(KeyCode.Q))
        {
            rightThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = -hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rightThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
        }
        else
        {
            rightThigh.useMotor = false;
        }

        // Left Thigh controls
        if (Input.GetKey(KeyCode.E))
        {
            leftThigh.useMotor = true;
            leftThighMotorRef.motorSpeed = -hingeSpeed;
            leftThigh.motor = leftThighMotorRef;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            leftThigh.useMotor = true;
            leftThighMotorRef.motorSpeed = hingeSpeed;
            leftThigh.motor = leftThighMotorRef;
        }
        else
        {
            leftThigh.useMotor = false;
        }

        // Rocket boots
        if (Input.GetKey(KeyCode.Space))
        {
            // Get the direction opposite to the right thigh
            Vector2 boostDirection = new Vector2(-rightThigh.transform.right.x, -rightThigh.transform.right.y);

            // Apply the force
            GetComponent<Rigidbody2D>().AddForce(boostDirection * boostForce);
            isBoosting = true;
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

}
