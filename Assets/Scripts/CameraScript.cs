using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Getting parameters and player gameobject
    public float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    public Transform player;
    public float aheadDistance;
    private float lookAhead;
    
    // Moves camera depending on where the player is, configurable to go slightly ahead is needed
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * speed);
    }
}
