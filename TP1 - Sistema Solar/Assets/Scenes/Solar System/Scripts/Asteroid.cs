using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    const float movementSpeed = 100.0f;
    const float targetY = -400.0f;

    void Update()
    {
        if (transform.position.y < targetY)
            //transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
       // else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        Destroy(gameObject);
    }
}
