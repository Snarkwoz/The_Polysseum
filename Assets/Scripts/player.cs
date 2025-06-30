using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    public LogicScript logic;
    private bool grounded;
    public Attack attackscript;
    public int health;
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;

    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (health <= 0)
        {
            Death();
        }

        if (Input.GetMouseButton(0) && cooldown_timer > cooldown)
        {
            attackscript.Missile(transform.localScale);
            cooldown_timer = 0;
        }
        cooldown_timer += Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "enemy")
        {
            Damage();
            // Knockback();
        }
        if (collision.gameObject.tag == "attack")
        {
            Damage();
            // Knockback();
        }
        if (collision.gameObject.tag == "death_plane")
        {
            Death();
        }
    }

    
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        grounded = false;
    }

    private void Damage()
    {
        Debug.Log("ow");
        health -= 1;
    }

    private void Death()
    {
        logic.gameover();
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
