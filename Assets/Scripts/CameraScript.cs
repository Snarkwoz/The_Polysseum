using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    public Transform player;
    public  float aheadDistance;
    private float lookAhead;
    
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * speed);
    }
}
