using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private bool isgrounded;

    public LogicScript logic;
    public Attack attackscript;

    public int health;
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;
    private float iframes = Mathf.Infinity;

    public GameObject box_enemy;
    public GameObject right_spawner;

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
        
        if (Input.GetKey(KeyCode.Space) && isgrounded)
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

        iframes += Time.deltaTime;
    }

    public void ReceiveParameter(bool grounded)
    {
        isgrounded = grounded;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy_attack")
        {
            Damage();
        }
        if (collision.gameObject.tag == "enemy")
        {
            Damage();
        }
        if (collision.gameObject.tag == "death_plane")
        {
            Death();
        }
    }
    
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
    }

    private void Damage()
    {
        if (iframes > 0.7)
        {
            health -= 1;
            iframes = 0;
        }
    }

    private void Death()
    {
        logic.gameover();
        gameObject.SetActive(false);
    }
}
