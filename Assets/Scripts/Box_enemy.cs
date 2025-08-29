using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private SpriteRenderer rend;
    public Color red;
    public Color yellow;
    private float timer;

    public BoxCollider2D boxcollider;
    public Attack attackscript;
    

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

        if (timer > 1)
        {
            attackscript.Missile(-transform.localScale);
            timer = 0;
        }
        
        timer += Time.deltaTime;
    }

    

    private void TurnLeft()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        Debug.Log("left");
    }
    private void TurnRight()
    {
        transform.localScale = new Vector3(-1.2f, 1.2f, 1f);
        Debug.Log("right");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            Damage();
        }
    }

    public void CollisionDetected(EnemyDetection Detection)
    {
        Debug.Log("collided");
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
