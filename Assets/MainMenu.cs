using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public AudioSource audioSource;
    public void OnClick() // in inspector, make sure that your OnClick event is this!
    {
       
        StartCoroutine(MainMenuWait()); //Coroutine Starts so it waits 2 seconds before game launche's


    }
 
    IEnumerator MainMenuWait()
    {
                                               
        yield return new WaitForSeconds(2);      //MainMenuWaitIsCalled"
        PlayGame();
       
    }

  
  

    public void PlayButton()
    {
        
        audioSource.Play();
    }

    public void PlayGame()
    {
        
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        
        
    }

   


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
        


    }
}
