using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletTarget target = collision.gameObject.GetComponent<BulletTarget>();
        if (target != null)
        {
            target.TakeDamage();
        }
        Destroy(gameObject);
    }
}