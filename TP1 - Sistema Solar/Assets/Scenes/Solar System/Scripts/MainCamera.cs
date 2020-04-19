using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    const float InitialOffsetY = 700.0f;
    const float InitialOffsetZ = -400.0f;

    [HideInInspector] public int maxPivotNumber = 10;

    public Vector3 offset = Vector3.zero;

    public GameObject pivot;

    public List<GameObject> pivots = new List<GameObject>();

    void Start()
    {
        offset = new Vector3(0, InitialOffsetY, InitialOffsetZ);
    }

    void Update()
    {
        CheckInput();

        transform.position = pivot.transform.position + offset;
    }

    void CheckInput()
    {
        for (int i = 0; i < maxPivotNumber; i++)
        {
            if (Input.GetKeyDown("[" + i.ToString() + "]"))
                pivot = pivots[i];
        }
    }
}
