using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    const float TorqueForce = 200.0f;
    const float MaxTorqueSpeed = 50.0f;

    const float ThrottleForce = 1000.0f;
    const float MaxThrottleSpeed = 50.0f;

    const float BrakeForce = 1000.0f;
    const float MaxBrakeSpeed = 50.0f;

    const float FrictionForce = 500.0f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Torque") && Input.GetAxis("Torque") < MaxTorqueSpeed)
        {
            rb.AddTorque(0, Input.GetAxis("Torque") * TorqueForce * Time.deltaTime, 0);
        }

        if (Input.GetButton("Throttle") && Input.GetAxis("Throttle") < MaxThrottleSpeed)
        {
            rb.AddForce(transform.forward * ThrottleForce * Time.deltaTime);
        }

        if (Input.GetButton("Brake") && Input.GetAxis("Brake") < MaxBrakeSpeed)
        {
            rb.AddForce(transform.forward * -BrakeForce * Time.deltaTime);
        }
    }
}
