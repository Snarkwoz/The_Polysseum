using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private bool grounded;
    public player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = true;

            sendGrounded(grounded);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = false;

            sendGrounded(grounded);
        }
    }

    public void sendGrounded(bool grounded)
    {
        player.ReceiveParameter(grounded);
    }
}
