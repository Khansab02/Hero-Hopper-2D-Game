using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class P_Mov : MonoBehaviour
{
 
    public float speed = 2f;
  
    public float jumpspeed = 0.5f;

    public Transform groundCheck; 
    public LayerMask groundLayer; 
    Rigidbody rb;
    private bool isGrounded = true;
    public GameObject bullet;
    public Transform point;
    public AudioClip audioClip;
    public AudioSource AudioSource;
    public GameObject Gameover; // Reference to the pause menu panel
    public Text GameoverText;


    private void Start()
    {
    
     
        AudioSource.clip = audioClip;
        AudioSource.Play();
        rb = GetComponent<Rigidbody>();
     
   
    }
   
    private void Update()
    {
        Vector3 movdir = new Vector3(0, 0, 0);
       if (Input.GetKey(KeyCode.A))
        {
            Flip();
            movdir.x = -1f;
        }
       if (Input.GetKey(KeyCode.D))
        {
            Flip();
            movdir.x = +1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Fire();
        }
       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        
            rb.AddForce(Vector3.up * jumpspeed,ForceMode.Impulse);
           isGrounded = false;
        }
        transform.position += movdir * speed * Time.deltaTime;
    }
    void Flip()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 180, 0);
        }
    }
    private void Fire()
    {
        // Instantiate the projectile at the fire point
        Instantiate(bullet, point.position, point.rotation);
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        // Prevent the player from moving or rotating when colliding with other objects
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) // Change "Obstacle" to your desired layer
        {
            // Reset the player's velocity to zero
            rb.velocity = Vector2.zero;

            // Optionally, you can also freeze rotation
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if(collision.gameObject.tag=="enemy")
        {
           
            Destroy(gameObject);
            Gameover.SetActive(true);
            StartCoroutine(Over());
           
            SceneManager.LoadScene("Menu");
      
           
        }
    }
    IEnumerator Over()
    {
      
        yield return new WaitForSeconds(10f);
    }
    private void OnCollisionExit(Collision collision)
    {
        // Allow movement again when not colliding
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            rb.constraints = RigidbodyConstraints.None; // Remove constraints
        }
    }
}
