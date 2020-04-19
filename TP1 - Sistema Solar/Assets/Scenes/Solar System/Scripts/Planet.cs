using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    const float InitialRotationSpeed = 15.0f;

    const float TranslationSpeedBase = 0.5f;
    const float MaxTranslationAngle = 360.0f;

    public float rotationSpeed;

    public float translationSpeed;
    float traslationRadius;
    float translationAngle = 0;
    float newX;
    float newZ;
    Vector3 newPosition = new Vector3();

    float transparencyValue = 0.25f;
    Color color;

    void Start()
    {
        rotationSpeed = InitialRotationSpeed;

        traslationRadius = transform.localPosition.z;
        translationSpeed = TranslationSpeedBase / transform.localScale.z;
        newPosition = Vector3.zero;

        color = GetComponent<Renderer>().material.color;
    }

    void FixedUpdate()
    {
        Rotate();
        Translate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }

    void Translate()
    {
        translationAngle += translationSpeed * Time.deltaTime;
        newX = traslationRadius * Mathf.Cos(translationAngle * Mathf.Deg2Rad);
        newZ = traslationRadius * Mathf.Sin(translationAngle * Mathf.Deg2Rad);
        newPosition.Set(newX, transform.localPosition.y, newZ);
        transform.localPosition = newPosition;

        if (translationAngle > MaxTranslationAngle)
            translationAngle -= MaxTranslationAngle;
    }

    void OnTriggerEnter(Collider other)
    {
        color.a = transparencyValue;
        GetComponent<Renderer>().material.color = color;
    }

    private void OnTriggerExit(Collider other)
    {
        color.a = 1.0f;
        GetComponent<Renderer>().material.color = color;
    }
}
