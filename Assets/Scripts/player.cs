using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;
    public LogicScript logic;
    public bool alive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && alive == true)
        {
            body.linearVelocity = Vector2.up * speed;
        }

        if (Input.GetKeyDown(KeyCode.A) == true && alive == true)
        {
            body.linearVelocity = Vector2.left * speed;
        }

        if (Input.GetKeyDown(KeyCode.S) == true && alive == true)
        {
            body.linearVelocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(KeyCode.D) == true && alive == true)
        {
            body.linearVelocity = Vector2.right * speed;
        }
        
    }

    private void death(Collision2D collision)
    {
        logic.gameover();
        alive = false;
    }
}
