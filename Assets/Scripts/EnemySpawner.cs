using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject box_enemy;
    public float spawn_timer;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawn_timer)
        {
            Debug.Log("Spawned");
            Instantiate(box_enemy, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("t"))
        {
            Instantiate(box_enemy, transform.position, transform.rotation);
        }
    }
}
