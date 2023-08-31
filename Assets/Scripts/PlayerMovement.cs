using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

   

    private Vector3 velocity;
    private float zRotationVelocity;

    public ScreenBounds screenbounds;

    public AudioSource audiosources;

    public AudioClip shipDestroy;


    public void Start()
    {
      
        audiosources.GetComponent<AudioSource>();
    }


    private void Update()
    {
        // apply forward input
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;
        Vector3 tempPosition = transform.localPosition + velocity * Time.deltaTime;
        if (screenbounds.IsOutOfBounds(tempPosition))
        {
            Vector2 newPosition = screenbounds.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }
        // apply turn input
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }






    IEnumerator PlayerHit() // Sound and Animation did not have time to run when changing the scene between death so this IEnumerator is doing it with 2 seconds delay.
    {
        Debug.Log("PlayerHit!");
        yield return new WaitForSeconds(2);
        Destroy(gameObject, 0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) // Im passing coroutine inside collision enter and code runs it first 2 sec delay and then destroy.
        {
            StartCoroutine(PlayerHit());
            PlayerHit();
            PlayShipDestroy();
          

        }
       
        if (collision.gameObject.CompareTag("MediumAsteroid"))
        {
            StartCoroutine(PlayerHit());
            PlayerHit();
            PlayShipDestroy();
        }


        if (collision.gameObject.CompareTag("SmallAsteroid"))
        {
            StartCoroutine(PlayerHit());
            PlayerHit();
            PlayShipDestroy();
        }
       
        
    }
   

    void PlayShipDestroy()
    {
        audiosources.clip = shipDestroy;
        audiosources.PlayOneShot(shipDestroy);
    }

}
