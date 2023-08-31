using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Die();
        }



        

        if (collision.gameObject.CompareTag("MediumAsteroid"))
        {
            Die();
        }


        if (collision.gameObject.CompareTag("SmallAsteroid"))
        {
            Die();
        }
    }


    private void Die()
    {
        anim.SetTrigger("dead");
    }
}