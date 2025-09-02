using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Getting enemy gameobject and parameters
    public GameObject box_enemy;
    public float spawn_timer;
    private float timer;

    void Update()
    {
        // Doesn't spawn enemy until the specified time to desync stacked enemy's attacks
        timer += Time.deltaTime;
        if (timer >= spawn_timer)
        {
            Instantiate(box_enemy, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
