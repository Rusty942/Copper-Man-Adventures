using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Get the player limbs
    public HingeJoint2D rightThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftThigh;
    public HingeJoint2D leftCalf;

    // Set the speed the limbs move at
    public float hingeSpeed = 40f;
    public float acceleration = 10f;

    // Reference to player limb motors
    private JointMotor2D rightThighMotorRef;
    private JointMotor2D rightCalfMotorRef;
    private JointMotor2D leftThighMotorRef;
    private JointMotor2D leftCalfMotorRef;

    void Start()
    {
        // Set the motors to the limb motors
        rightThighMotorRef = rightThigh.motor;
        rightCalfMotorRef = rightCalf.motor;
        leftThighMotorRef = leftThigh.motor;
        leftCalfMotorRef = leftCalf.motor;
    }

    void Update()
    {
        MoveLimb(rightThigh, KeyCode.Q, KeyCode.W);
        MoveLimb(leftThigh, KeyCode.Q, KeyCode.W, -1f);
        MoveLimb(rightCalf, KeyCode.E, KeyCode.R);
        MoveLimb(leftCalf, KeyCode.E, KeyCode.R, -1f);
    }

    void MoveLimb(HingeJoint2D limb, KeyCode clockwiseKey, KeyCode anticlockwiseKey, float directionMultiplier = 1f)
    {
        JointMotor2D motor = limb.motor;
        motor.motorSpeed = Mathf.MoveTowards(motor.motorSpeed, 0f, acceleration * Time.deltaTime);

        if (Input.GetKey(clockwiseKey))
        {
            motor.motorSpeed = -hingeSpeed * directionMultiplier;
        }
        else if (Input.GetKey(anticlockwiseKey))
        {
            motor.motorSpeed = hingeSpeed * directionMultiplier;
        }

        limb.motor = motor;
        limb.useMotor = Mathf.Abs(motor.motorSpeed) > 0.01f;
    }
}