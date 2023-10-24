using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}