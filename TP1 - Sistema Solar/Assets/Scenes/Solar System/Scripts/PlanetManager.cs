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

    public int planetAmount = 0;

    public GameObject planetPrefab;

    public MainCamera cameraScript;

    [HideInInspector] public List<GameObject> planets = new List<GameObject>();
    public List<Material> planetMaterials = new List<Material>();

    void Start()
    {
        int materialId;

        float size;

        for (int i = 0; i < planetAmount; i++)
        {
            planets.Add(Instantiate(planetPrefab));
            planets[i].transform.parent = GameObject.Find("Sun").transform;

            if (i == 0)
            {
                planets[i].transform.position = new Vector3(0, 0, FirstPlanetDistance);
            }
            else
            {
                planets[i].transform.position = new Vector3(0, 0, planets[i - 1].transform.position.z + Random.Range(MinDistance, MaxDistance));
            }

            size = Random.Range(MinSize, MaxSize);
            planets[i].transform.localScale = new Vector3(size, size, size);

            do materialId = Random.Range(0, planetMaterials.Count - 1);
            while (!planetMaterials[materialId]);
            planets[i].GetComponent<MeshRenderer>().material = planetMaterials[materialId];

            if (i < cameraScript.maxPivotNumber - 1)
                cameraScript.pivots.Add(planets[i]);
        }
    }
}
