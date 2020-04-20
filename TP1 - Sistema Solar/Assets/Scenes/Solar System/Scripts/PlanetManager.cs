using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    const float FirstPlanetDistance = 175.0f;
    const float MinDistance = 30.0f;
    const float MaxDistance = 100.0f;
    const float MinSize = 0.05f;
    const float MaxSize = 0.2f;

    public int planetAmount;
    int materialId;

    float size;

    Vector3 initialPosition;

    public GameObject planetPrefab;

    public MainCamera cameraScript;

    [HideInInspector] public List<GameObject> planets = new List<GameObject>();
    public List<Material> planetMaterials = new List<Material>();

    void Start()
    {
        for (int i = 0; i < planetAmount; i++)
        {
            if (i == 0)
            {
                initialPosition = new Vector3(0, 0, FirstPlanetDistance);

                planets.Add(Instantiate(planetPrefab, initialPosition, Quaternion.identity, GameObject.Find("Sun").transform));
            }
            else
            {
                initialPosition = new Vector3(0, 0, planets[i - 1].transform.position.z + Random.Range(MinDistance, MaxDistance));

                planets.Add(Instantiate(planetPrefab, initialPosition, Quaternion.identity, GameObject.Find("Sun").transform));
            }

            size = Random.Range(MinSize, MaxSize);
            planets[i].transform.localScale = new Vector3(size, size, size);

            do materialId = Random.Range(0, planetMaterials.Count - 1);
            while (!planetMaterials[materialId]);
            planets[i].GetComponent<MeshRenderer>().material = planetMaterials[materialId];

            if (i < cameraScript.maxPivotNumber - 2)
                cameraScript.pivots.Add(planets[i]);
        }
    }
}
