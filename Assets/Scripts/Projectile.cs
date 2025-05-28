using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit;
    public BoxCollider2D collider;
    private float direction;

    private void Update()
    {
        if (hit)
        {
            return;
        }

        float movespeed = speed * Time.deltaTime * direction;
        transform.Translate(movespeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        collider.enabled = false;
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        collider.enabled = true;

    }
}
