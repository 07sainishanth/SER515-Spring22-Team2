using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelDrive : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private bool breaking;
    private float steerangle;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxsteerangle;

    [SerializeField] private WheelCollider FL_WheelCollider;
    [SerializeField] private WheelCollider FR_WheelCollider;
    [SerializeField] private WheelCollider RL_WheelCollider;
    [SerializeField] private WheelCollider RR_WheelCollider;

    [SerializeField] private Transform FL_Wheel;
    [SerializeField] private Transform FR_Wheel;
    [SerializeField] private Transform RL_Wheel;
    [SerializeField] private Transform RR_Wheel;

    private void FixedUpdate()
    {
        GetInput();
        Control_Motor();
        Control_Steering();
        Control_wheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        breaking = Input.GetKey(KeyCode.Space);
    }

    private void Control_Motor()
    {
        RL_WheelCollider.motorTorque = verticalInput * motorForce;
        RR_WheelCollider.motorTorque = verticalInput * motorForce;
        breakForce = breaking ? breakForce : 0f;

        if (breaking)
        {
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        FL_WheelCollider.brakeTorque = breakForce;
        RL_WheelCollider.brakeTorque = breakForce;
        RR_WheelCollider.brakeTorque = breakForce;
        FR_WheelCollider.brakeTorque = breakForce;
    }
    private void Control_Steering()
    {
        steerangle = maxsteerangle * horizontalInput;
        FL_WheelCollider.steerAngle = steerangle;
        FR_WheelCollider.steerAngle = steerangle;
    }

    private void Control_wheels()
    {
        UpdateSingleWheel(FL_WheelCollider, FL_Wheel);
        UpdateSingleWheel(RL_WheelCollider, RL_Wheel);
        UpdateSingleWheel(FR_WheelCollider, FR_Wheel);
        UpdateSingleWheel(RR_WheelCollider, RR_Wheel);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform Wheel)
    {
        Vector3 pose;
        Quaternion quat;
        WheelCollider.GetWorldPose(out pose, out quat);
        Wheel.rotation = quat;
        Wheel.position = pose;
    }
}
