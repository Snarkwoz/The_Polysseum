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
    public GameObject box_enemy;

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

        if (grounded == true)
        {
            Debug.Log("grounded");
        }
        if (grounded == false)
        {
            Debug.Log("not grounded");
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

        if (Input.GetKeyDown("t"))
        {
            Instantiate(box_enemy);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag != "ground")
        {
            grounded = false;
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
