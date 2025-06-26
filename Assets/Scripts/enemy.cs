using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private SpriteRenderer rend;
    public Color red;
    public Color yellow;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (health == 2)
        {
            rend.color = yellow;
        }
        if (health == 1)
        {
            rend.color = red;
        }
        
        // if (hitplayer()) {damageplayer};
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            Damage();
        }
    }

    private void Damage()
    {
        health -= 1;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
