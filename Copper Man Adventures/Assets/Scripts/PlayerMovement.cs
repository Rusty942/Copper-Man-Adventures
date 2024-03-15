using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HingeJoint2D rightThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftThigh;
    public HingeJoint2D leftCalf;

    private JointMotor2D rightThighMotorRef;
    private JointMotor2D rightCalfMotorRef;
    private JointMotor2D leftThighMotorRef;
    private JointMotor2D leftCalfMotorRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
