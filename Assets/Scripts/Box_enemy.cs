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
    public float verticalrange;
    public float colliderdistance;

    public GameObject detection;
    

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

    private bool PlayerToLeft()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * detectionrange * colliderdistance, 
        new Vector3(boxcollider.bounds.size.x * detectionrange, boxcollider.bounds.size.y * verticalrange, boxcollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * detectionrange * colliderdistance, 
        new Vector3(boxcollider.bounds.size.x * detectionrange, boxcollider.bounds.size.y * verticalrange, boxcollider.bounds.size.z));
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
