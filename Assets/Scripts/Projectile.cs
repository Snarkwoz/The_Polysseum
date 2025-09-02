using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    // Getting parameters and body
    public float speed;
    private bool hit;
    public float lifetime;
    private Rigidbody2D body;
    public bool facingright;
    private float test;

    // Gets body and recieves direction
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (facingright == true)
        {
            body.linearVelocity = transform.right * speed;
        }
        if (facingright == false)
        {
            body.linearVelocity = transform.right * speed * -1;
        }
    }

    private void Update()
    {
        // Checks if hits anything
        if (hit == true)
        {
            Deactivate();
        }

        // Expires after 5 seconds
        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            Deactivate();
        }
    }

    // Checks for any collisions, all of which trigger hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "ground")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "player")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "enemy_attack")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "enemy")
        {
            hit = true;
        }
    }

    // Deactivates the missile
    private void Deactivate()
    {
        Destroy(gameObject);
    }
}