using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject box_enemy;

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            Instantiate(box_enemy, transform.position, transform.rotation);
        }
    }
}
