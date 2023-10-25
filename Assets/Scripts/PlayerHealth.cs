using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public void RecoverHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Handle player death here
        Debug.Log("Player is dead!");
        //Reaload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Call this method when an explosion occurs
    public void OnExplosion()
    {
        if (!isTakingDamage)
        {
            StartCoroutine(ApplyDamageOverTime(1));
            Debug.Log("Player is taking damage!");
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