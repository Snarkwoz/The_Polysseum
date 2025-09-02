using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Getting parameters and player gameobject
    private bool grounded;
    public player player;

    // Checking if colliding with ground
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = true;

            sendGrounded(grounded);
        }
    }
    // Checking if leaves ground
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            grounded = false;

            sendGrounded(grounded);
        }
    }

    // Sends grounded parameter to player script
    public void sendGrounded(bool grounded)
    {
        player.ReceiveParameter(grounded);
    }
}
