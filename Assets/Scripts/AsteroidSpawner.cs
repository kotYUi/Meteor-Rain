using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius = 250f;
    public Rigidbody asteriodPrefab;
    public float spawnRate = 5f;
    public float variance = 1f;
    public Transform target;
    public bool spawnAsteroid = false;
    public List<Rigidbody> allAsteroid = new List<Rigidbody>();

    private void Start()
    {
        StartCoroutine(CreateAsteroids());
    }

    IEnumerator CreateAsteroids()
    {
        while (true)
        {
            float nextSpawnTime = spawnRate + Random.Range(-variance, variance);

            yield return new WaitForSeconds(nextSpawnTime);
            yield return new WaitForFixedUpdate();

            CreateNewAsteroid();
        }
    }

    void CreateNewAsteroid()
    {
        if (spawnAsteroid == false) return;

        var asteroidPosition = Random.onUnitSphere * radius;
        asteroidPosition.Scale(transform.lossyScale);
        asteroidPosition += transform.position;

        var newAsteroid = Instantiate(asteriodPrefab);
        newAsteroid.transform.position = asteroidPosition;
        newAsteroid.transform.LookAt(target);
        allAsteroid.Add(newAsteroid);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    public void DestroyAllAsteroids()
    {
        foreach (var asteroid in allAsteroid)
        {
            if (asteroid != null) 
            {
                Destroy(asteroid.gameObject);
            }
        }
        allAsteroid.Clear(); 
    }
}
