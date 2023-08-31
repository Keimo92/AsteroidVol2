using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidHit : MonoBehaviour
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
            PlaySmallAsteroidDestroy();
            
        }
    }




    public void PlaySmallAsteroidDestroy()
    {
        audiosource.clip = explode;
        audiosource.PlayOneShot(audiosource.clip);
    }
}
