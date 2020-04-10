using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    const float AngleIncrementBase = 1.0f;
    const float MaxAngle = 360.0f;

    float radius;
    float angle = 0;
    float angleIncrement;

    void Start()
    {
        radius = transform.localPosition.z;
        angleIncrement = AngleIncrementBase / transform.localScale.z;
    }

    void Update()
    {
        transform.localPosition = new Vector3(radius * Mathf.Cos(angle * Mathf.Deg2Rad), transform.localPosition.y, radius * Mathf.Sin(angle * Mathf.Deg2Rad));

        if (angle > MaxAngle)
            angle -= MaxAngle;
        angle += angleIncrement;
    }
}
