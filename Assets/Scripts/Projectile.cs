using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit;
    public float lifetime;
    private Rigidbody2D body;
    public bool facingright;
    private float test;

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
        if (hit == true)
        {
            Deactivate();
        }

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            Deactivate();
        }
    }

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

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}