using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initially get the player limbs
    public HingeJoint2D rightThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftThigh;
    public HingeJoint2D leftCalf;

    //Refrence to player limb motors
    private JointMotor2D rightThighMotorRef;
    private JointMotor2D rightCalfMotorRef;
    private JointMotor2D leftThighMotorRef;
    private JointMotor2D leftCalfMotorRef;

    //Set the speed the limbs move at
    public float hingeSpeed = 40;

    // Start is called before the first frame update
    void Start()
    {
        //Set the motors to the limb motors
        rightThighMotorRef = rightThigh.motor;
        rightCalfMotorRef = rightCalf.motor;
        leftThighMotorRef = leftThigh.motor;
        leftCalfMotorRef = leftCalf.motor;
    }

    // Update is called once per frame
    void Update()
    {
        //Thigh controls
        if (Input.GetKey(KeyCode.Q))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = -hingeSpeed;
            leftThighMotorRef.motorSpeed = hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = hingeSpeed;
            leftThighMotorRef.motorSpeed = -hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        }
        else
        {
            rightThigh.useMotor =false;
            leftThigh.useMotor = false;
        }

       
        //Calf controls
        if (Input.GetKey(KeyCode.E))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;
            rightCalfMotorRef.motorSpeed = -hingeSpeed;
            leftCalfMotorRef.motorSpeed = hingeSpeed;
            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;
            rightCalfMotorRef.motorSpeed = hingeSpeed;
            leftCalfMotorRef.motorSpeed = -hingeSpeed;
            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else
        {
            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
        }

    }
}
