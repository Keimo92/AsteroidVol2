using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship_Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 10f;

   public AudioClip shoot;

   public AudioSource audiosource;



    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change to your desired input
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.up * bulletSpeed;

        PlayShootSound();

        // Destroy the bullet after a certain time or when it goes off-screen
        Destroy(bullet, 3f); // Adjust the time as needed
    }

   void PlayShootSound()
    {

        audiosource.clip = shoot;
        audiosource.PlayOneShot(audiosource.clip);
    }
   
}

