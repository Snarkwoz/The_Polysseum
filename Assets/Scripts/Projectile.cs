using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit = false;
    public BoxCollider2D collider;
    private float direction;
    private float lifetime = 0;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.linearVelocity = transform.right * speed;
    }

    private void Update()
    {
        if (hit = true)
        {
            Deactivate();
            return;
        }

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            Deactivate();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "wall")
    //    {
    //        hit = true;
    //    }
    //}

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
