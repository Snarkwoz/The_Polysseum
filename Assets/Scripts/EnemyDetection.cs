using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject box_enemy;

    public void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "player")
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "player")
    }
}
