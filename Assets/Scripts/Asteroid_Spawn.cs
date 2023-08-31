using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawn : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 2f;
    public float spawnRadius = 5f;
    public float minAsteroidSpeed = 1f;
    public float maxAsteroidSpeed = 3f;

    

    private void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, spawnRate);
    }

    void SpawnAsteroid()
    {
        
        Vector3 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
       

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
     
        Rigidbody2D asteroidRb = asteroid.GetComponent<Rigidbody2D>();

        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float speed = Random.Range(minAsteroidSpeed, maxAsteroidSpeed);

        asteroidRb.velocity = direction * speed;

        // Destroy the asteroid after a certain time or when it goes off-screen
        Destroy(asteroid, 15f); // Adjust the time as needed
    }
}

