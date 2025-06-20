using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit;
    public BoxCollider2D collider;
    private float direction;
    private float lifetime = 0;
    private Rigidbody2D body;
    private int directionTracker = 1;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (Input.GetAxis("Horizontal") < 0)
        {
            directionTracker = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            directionTracker = 1;
        }

        body.linearVelocity = transform.right * speed * directionTracker;
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
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
