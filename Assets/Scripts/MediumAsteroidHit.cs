using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAsteroidHit : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip explode;




    private void Start()
    {
        audiosource.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject,0.04f);
            PlayAsteroidDestroy();
            Scoring.totalScore += 1;
           
        }
    }




    public void PlayAsteroidDestroy()
    {
        audiosource.clip = explode;
        audiosource.PlayOneShot(audiosource.clip);
       
    }
}
