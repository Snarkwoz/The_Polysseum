using UnityEngine;

public class Attack : MonoBehaviour
{
    public float cooldown;
    private float cooldown_timer = Mathf.Infinity;
    public player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown_timer > cooldown)
        {
            
        }

        cooldown_timer += Time.deltaTime;
    }

}
    