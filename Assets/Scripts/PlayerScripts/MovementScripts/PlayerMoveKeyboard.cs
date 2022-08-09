using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    Animator anim;

    public FreeMovementMotor motor;
    public Transform playerTransform;

    Quaternion screenMovementSpace;
    Vector3 screenMovementFoward;
    Vector3 screenMovementRight;

    string AXIS_X = "Horizontal";
    string AXIS_Y = "Vertical";
    string Animation_Run = "Run";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        motor.movementDirection = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementFoward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        motor.movementDirection = Input.GetAxis(AXIS_X) * screenMovementRight + Input.GetAxis(AXIS_Y) * screenMovementFoward;
        if(Input.GetAxis(AXIS_X) !=0 || Input.GetAxis(AXIS_Y) != 0)
        {
            anim.SetBool(Animation_Run, true);
        }
        else
        {
            anim.SetBool(Animation_Run, false);
        }

        if (motor.movementDirection.sqrMagnitude > 1)
        {
            motor.movementDirection.Normalize();
        }
    }
}
