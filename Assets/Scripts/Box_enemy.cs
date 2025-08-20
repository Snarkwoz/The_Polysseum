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
    public LayerMask playerLayer;
    public float detectionrange;
    public float colliderdistance;
    

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

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * detectionrange * transform.localScale.x * colliderdistance, 
        new Vector3(boxcollider.bounds.size.x * detectionrange, boxcollider.bounds.size.y, boxcollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);
        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * detectionrange * transform.localScale.x * colliderdistance, 
        new Vector3(boxcollider.bounds.size.x * detectionrange, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
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
