using UnityEngine;

public class player : MonoBehaviour
{
    // Getting parameters, other scripts etc
    public float speed;
    public float jump;
    private bool isgrounded;
    public int health;
    private string healthUI;
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;
    private float iframes = Mathf.Infinity;

    public Rigidbody2D rb;
    private SpriteRenderer rend;
    public Color pink;
    public Color red;

    public LogicScript logic;
    public Attack attackscript;

    void Start()
    {
        // Getting the sprite renderer so the colour can be changed
        rend = GetComponent<SpriteRenderer>();

        health_display();
    }

    void Update()
    {
        // Movement
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        // Jump if on ground
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            Jump();
        }

        // Fire missile
        if (Input.GetMouseButton(0) && cooldown_timer > cooldown)
        {
            attackscript.Missile(transform.localScale);
            cooldown_timer = 0;
        }
        cooldown_timer += Time.deltaTime;

        // Invincibility frames
        iframes += Time.deltaTime;

        if (iframes > 0.7)
        {
            rend.color = pink;
        }

        // Death
        if (health <= 0)
        {
            Death();
        }
    }

    // Recieves grounded bool from Hitbox.cs
    public void ReceiveParameter(bool grounded)
    {
        isgrounded = grounded;
    }

    // Collision detection
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
        if (collision.gameObject.tag == "end_platform")
        {
            Victory();
        }
    }
    
    // Jump function
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
    }

    // Checks if player is invincible, then damages player and turns it red until iframes expire
    private void Damage()
    {
        if (iframes > 0.7)
        {
            health -= 1;
            iframes = 0;
            rend.color = red;
            health_display();
        }
    }

    // Sends the health as a string to LogicScript to be displayed
    private void health_display()
    {
        healthUI = health.ToString();
        logic.GetHealthDisplay(healthUI);
    }

    // Victory function
    private void Victory()
    {
        logic.Victory();
        gameObject.SetActive(false);
    }

    // Death funciton
    private void Death()
    {
        logic.gameover();
        gameObject.SetActive(false);
    }
}
