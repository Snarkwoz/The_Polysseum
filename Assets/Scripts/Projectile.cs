using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Projectile : MonoBehaviour
{
    public float speed;
    private bool hit = false;
    public BoxCollider2D collider;
    private float direction;
    private float lifetime;

    private void Update()
    {
        if (hit = true)
        {
            Deactivate();
            return;
        }

        float movespeed = speed * Time.deltaTime * direction;
        transform.Translate(movespeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            Deactivate()
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            hit = true;
        }
    }

    public void SetDirection(float _direction)
    {
        gameObject.SetActive(true);
        direction = _direction;
        hit = false;
        collider.enabled = true;

        float localscaleX = transform.localScale.x;
        if (Mathf.Sign(localscaleX) != _direction)
        {
            localscaleX = -localscaleX;
        }

        transform.localScale = new Vector3(localscaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
