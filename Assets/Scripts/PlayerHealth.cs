using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float checkTime = 1f;
    private bool isTakingDamage = false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player death here
        Debug.Log("Player is dead!");
        // You can disable the player, show a game over screen, etc.
    }

    // Call this method when an explosion occurs
    public void OnExplosion()
    {
        if (!isTakingDamage)
        {
            StartCoroutine(ApplyDamageOverTime(1));
        }
    }

    private IEnumerator ApplyDamageOverTime(int damage)
    {
        isTakingDamage = true;
        TakeDamage(damage);
        yield return new WaitForSeconds(checkTime);
        isTakingDamage = false;
    }
}