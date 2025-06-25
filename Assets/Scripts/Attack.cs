using UnityEngine;

public class Attack : MonoBehaviour
{
    public player player;
    public Transform missilePoint;
    public GameObject missile_prefab;

    private void Missile(Vector3 direction)
    {
        GameObject newmissile = Instantiate(missile_prefab, missilePoint.position, missilePoint.rotation);
        if (direction.x < 0)
        {
             newmissile.GetComponent <Projectile>().facingright = false;
        }
        if (direction.x > 0)
        {
             newmissile.GetComponent <Projectile>().facingright = true;
        }
        
       
    }
}
    