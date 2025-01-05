using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    public float speed = 5f; // Speed of the projectile
    private Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.velocity = transform.forward * speed;
        rb.velocity = transform.right * speed;

        // Destroy the projectile after 5 seconds to prevent cluttering the scene
        Destroy(gameObject, 2f);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        // Handle collision with other objects
        // You can add damage logic here if needed
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject); // Destroy the projectile on collision
        }
    }
}