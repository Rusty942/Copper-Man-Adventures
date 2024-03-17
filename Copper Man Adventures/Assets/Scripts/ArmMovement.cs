using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    // Initially get the player arms
    public HingeJoint2D rightArm;
    public HingeJoint2D leftArm;

    // Set the speed the arms move at
    public float hingeSpeed = 40;

    // Update is called once per frame
    void Update()
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