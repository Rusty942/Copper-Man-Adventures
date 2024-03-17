using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Initially get the player limbs
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightArm; // New arm
    public HingeJoint2D leftArm;  // New arm

    // Set the speed the limbs move at
    public float hingeSpeed = 40;

    // Rocket boot force
    public float boostForce = 100f;

    // Animator
    public Animator animRight;
    public Animator animLeft;
    public bool isBoosting = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the motors to the limb motors
        SetHingeMotors(rightArm, leftArm);
    }

    // Update is called once per frame
    void Update()
    {
        // Right Thigh controls
        if (Input.GetKey(KeyCode.Q))
        {
            RotateThigh(rightThigh, -hingeSpeed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            RotateThigh(rightThigh, hingeSpeed);
        }

        // Left Thigh controls
        if (Input.GetKey(KeyCode.E))
        {
            RotateThigh(leftThigh, -hingeSpeed);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            RotateThigh(leftThigh, hingeSpeed);
        }

        // Rocket boots
        if (Input.GetKey(KeyCode.Space))
        {
            // Apply the force
            GetComponent<Rigidbody2D>().AddForce(transform.right * boostForce);
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }

        // Set animation parameters based on boosting state
        animRight.SetBool("boosting", isBoosting);
        animLeft.SetBool("boosting", isBoosting);

        // Point arms towards mouse cursor
        PointArmsTowardsMouse();
    }

    void SetHingeMotors(params HingeJoint2D[] hinges)
    {
        foreach (HingeJoint2D hinge in hinges)
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = 0; // Start with no speed
            hinge.motor = motor;
        }
    }

    void RotateThigh(HingeJoint2D thigh, float rotationSpeed)
    {
        JointMotor2D motor = thigh.motor;
        motor.motorSpeed = rotationSpeed;
        thigh.motor = motor;
    }

    void PointArmsTowardsMouse()
    {
        // Get the direction towards the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the motor speed for the arms
        RotateArm(rightArm, angle);
        RotateArm(leftArm, angle);
    }

    void RotateArm(HingeJoint2D arm, float angle)
    {
        JointMotor2D motor = arm.motor;
        motor.motorSpeed = -hingeSpeed * Mathf.Sign(angle - arm.transform.eulerAngles.z);
        arm.motor = motor;
    }
}