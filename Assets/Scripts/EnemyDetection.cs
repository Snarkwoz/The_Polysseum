using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject box_enemy;
    public enemy enemyscript;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "player")
        transform.parent.GetComponent<enemy>().CollisionDetected(this);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("exit");
        }
    }
}
