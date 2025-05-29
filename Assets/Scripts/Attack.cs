using UnityEngine;

public class Attack : MonoBehaviour
{
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;
    public player player;
    public Transform missilePoint;
    public GameObject[] missiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

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
        cooldown_timer = 0;

        missiles[findMissile()].transform.position = missilePoint.position;
        missiles[findMissile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int findMissile()
    {
        for (int i = 0; i < missiles.Length; i++)
        {
            if (!missiles[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
    