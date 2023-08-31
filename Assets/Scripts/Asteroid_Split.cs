using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Split : MonoBehaviour
{

    public GameObject mediumAsteroidPrefab;
    public GameObject smallAsteroidPrefab;
    public float splitForce = 5f;


    public AudioSource audiosource;
    public AudioClip explode;




    private void Start()
    {
        audiosource.GetComponent<AudioSource>();
    }

    public void Split()
    {
        Destroy(gameObject,0.04f); // Destroy the current asteroid

        PlayBigAsteroidDestroy();
        

        // Instantiate and split medium asteroids
        GameObject mediumAsteroid1 = Instantiate(mediumAsteroidPrefab, transform.position, Quaternion.identity);
        GameObject smallAsteroid2 = Instantiate(smallAsteroidPrefab, transform.position, Quaternion.identity);

        // Apply forces to simulate splitting
        Rigidbody2D rb1 = mediumAsteroid1.GetComponent<Rigidbody2D>();
        rb1.AddForce(new Vector2(-splitForce, splitForce), ForceMode2D.Impulse);

        Rigidbody2D rb2 = smallAsteroid2.GetComponent<Rigidbody2D>();
        rb2.AddForce(new Vector2(splitForce, splitForce), ForceMode2D.Impulse);

        // Destroy the medium asteroids after a certain time or when off-screen
        Destroy(mediumAsteroid1, 15f); // Adjust the time as needed
        Destroy(smallAsteroid2, 15f);

        // You can repeat the same process for spawning small asteroids from medium ones if desired
    }

    public void PlayBigAsteroidDestroy()
    {
        audiosource.clip = explode;
        audiosource.PlayOneShot(audiosource.clip);
    }
}

