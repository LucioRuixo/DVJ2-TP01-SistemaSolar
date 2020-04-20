using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    const float InitialY = 400.0f;
    const float MinInitialXZ = -500.0f;
    const float MaxInitialXZ = 500.0f;

    const double timerTarget = 15;

    public int asteroidAmount;

    public double timer = 0;

    Vector3 initialPosition;

    public GameObject asteroidPrefab;

    List<GameObject> asteroids = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < asteroidAmount; i++)
        {
            initialPosition = new Vector3(Random.Range(MinInitialXZ, MaxInitialXZ), InitialY, Random.Range(MinInitialXZ, MaxInitialXZ));

            asteroids.Add(Instantiate(asteroidPrefab, initialPosition, Quaternion.identity, GameObject.Find("Asteroids").transform));
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= timerTarget)
        { 
            for (int i = 0; i < asteroidAmount; i++)
            {
                initialPosition = new Vector3(Random.Range(MinInitialXZ, MaxInitialXZ), InitialY, Random.Range(MinInitialXZ, MaxInitialXZ));

                asteroids.Add(Instantiate(asteroidPrefab, initialPosition, Quaternion.identity, GameObject.Find("Asteroids").transform));
            }
        
            timer = 0;
        }
    }
}
