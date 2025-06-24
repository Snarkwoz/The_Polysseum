using UnityEngine;

public class Attack : MonoBehaviour
{
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;
    public player player;
    public Transform missilePoint;
    public GameObject missile_prefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown_timer > cooldown)
        {
            Missile();
        }

        cooldown_timer += Time.deltaTime;
    }

    private void Missile()
    {
        Instantiate(missile_prefab, missilePoint.position, missilePoint.rotation);
        cooldown_timer = 0;
    }
}
    