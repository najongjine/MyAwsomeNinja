using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movementDirection;

    private Rigidbody myBody;

    public float walkingSpeed=5f;
    public float walkingSnapyness=50f;
    public float turningSmooothing=0.3f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetVelocity = movementDirection * walkingSpeed;
        var deltaVelocity = targetVelocity - myBody.velocity;
        if (myBody.useGravity)
        {
            deltaVelocity.y = 0f;
        }
        myBody.AddForce(deltaVelocity * walkingSnapyness, ForceMode.Acceleration);

        var faceDir = movementDirection;
        if (faceDir == Vector3.zero)
        {
            myBody.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, faceDir, Vector3.up);
            myBody.angularVelocity = (Vector3.up * rotationAngle * turningSmooothing);
        }

    }
    float AngleAroundAxis(Vector3 dirA,Vector3 dirB,Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);
        var angle=Vector3.Angle(dirA, dirB);
        return angle*(Vector3.Dot(axis,Vector3.Cross(dirA,dirB))<0?-1:1);
    }

}
