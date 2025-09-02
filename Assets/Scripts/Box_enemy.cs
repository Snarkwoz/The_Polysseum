using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private SpriteRenderer rend;
    public Color red;
    public Color yellow;
    private float timer;

    // Getting collider and attack script
    public BoxCollider2D boxcollider;
    public Attack attackscript;

    void Start()
    {
        // Getting the sprite renderer so the colour can be changed
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Checks for death
        if (health <= 0)
        {
            Death();
        }

        // Changes colour depending on health
        if (health == 2)
        {
            rend.color = yellow;
        }
        if (health == 1)
        {
            rend.color = red;
        }

        // Fires a missile once per second
        if (timer > 1)
        {
            attackscript.Missile(-transform.localScale);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // Checks for collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            Damage();
        }
    }

    // Damages enemy
    private void Damage()
    {
        health -= 1;
    }

    // Kills the enemy
    private void Death()
    {
        Destroy(gameObject);
    }
}
