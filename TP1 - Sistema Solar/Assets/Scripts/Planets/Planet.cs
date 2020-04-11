using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    const float TranslationAngleIncrementBase = 0.015f;
    const float MaxTranslationAngle = 360.0f;

    float traslationRadius;
    float translationAngle = 0;
    float translationAngleIncrement;

    void Start()
    {
        traslationRadius = transform.localPosition.z;
        translationAngleIncrement = TranslationAngleIncrementBase / transform.localScale.z;
    }

    void FixedUpdate()
    {
        Translate();
    }

    void Translate()
    {
        transform.localPosition = new Vector3(traslationRadius * Mathf.Cos(translationAngle * Mathf.Deg2Rad), transform.localPosition.y, traslationRadius * Mathf.Sin(translationAngle * Mathf.Deg2Rad));

        if (translationAngle > MaxTranslationAngle)
            translationAngle -= MaxTranslationAngle;
        translationAngle += translationAngleIncrement;
    }
}
