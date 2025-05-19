using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            body.linearVelocity = Vector2.up * speed;
        }

        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            body.linearVelocity = Vector2.left * speed;
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            body.linearVelocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            body.linearVelocity = Vector2.right * speed;
        }
        

    }
}
