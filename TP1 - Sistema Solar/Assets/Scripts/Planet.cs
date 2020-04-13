using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    const float InitialRotationAngle = 0.5f;

    const float TranslationAngleIncrementBase = 0.015f;
    const float MaxTranslationAngle = 360.0f;

    public float rotationAngle;
    float lastRotationAngle;

    public float translationAngleIncrement;
    float traslationRadius;
    float translationAngle = 0;

    void Start()
    {
        rotationAngle = InitialRotationAngle;

        traslationRadius = transform.localPosition.z;
        translationAngleIncrement = TranslationAngleIncrementBase / transform.localScale.z;
    }

    void FixedUpdate()
    {
        Rotate();
        Translate();
    }

    void Rotate()
    {
        transform.Rotate(0.0f, rotationAngle, 0.0f);

    }

    void Translate()
    {
        transform.localPosition = new Vector3(traslationRadius * Mathf.Cos(translationAngle * Mathf.Deg2Rad), transform.localPosition.y, traslationRadius * Mathf.Sin(translationAngle * Mathf.Deg2Rad));

        if (translationAngle > MaxTranslationAngle)
            translationAngle -= MaxTranslationAngle;
        translationAngle += translationAngleIncrement;
    }
}
