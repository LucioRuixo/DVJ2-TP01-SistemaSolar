using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    const float limitDistance = 50.0f;

    List<GameObject> planets;

    void Start()
    {
        planets = GetComponent<PlanetManager>().planets;

        GetComponentInChildren<Light>().range = planets[planets.Count - 1].transform.position.z + limitDistance;
    }
}
