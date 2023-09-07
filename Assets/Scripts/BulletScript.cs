using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

   
  



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Asteroid_Split asteroid = collision.gameObject.GetComponent<Asteroid_Split>();

           
            

            if (asteroid != null)
            {
                Debug.Log("Hit");
                asteroid.Split();
                Destroy(gameObject);

            }

            

        }
        if (collision.gameObject.CompareTag("MediumAsteroid"))
        {
            
            Destroy(gameObject);
            Debug.Log("HitMedium");
           
        }

        if (collision.gameObject.CompareTag("SmallAsteroid"))
        {
            Destroy(gameObject);
            Debug.Log("HitSmaller");
           
        }
        
    }

    
}
