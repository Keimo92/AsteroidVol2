using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    public AudioSource audiosource;

    public AudioClip pop;

    // Start is called before the first frame update
    void Start()
    {
        audiosource.GetComponent<AudioSource>();
    }

   public void PressPlay()
    {
        Debug.Log("Trin");
        audiosource.clip = pop;
        audiosource.PlayOneShot(pop);
    }
}
