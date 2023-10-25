using System;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    public int health = 10;
    public GameObject deathEffect;
    public GameObject hitEffect;
    
    private SpriteRenderer spriteRenderer;
    public float flashTime = 0.1f;
    public int flashFrequency = 10;
    public Color flashColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        health -= 1;
        Instantiate(hitEffect, transform.position, transform.rotation);
        SpriteFlash();
        if (health <= 0)
        {
            Die();
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    private void SpriteFlash()
    {
        float timer = 0f;
        while (timer < flashTime)
        {
            timer += Time.deltaTime;
            if (timer % flashFrequency < flashFrequency / 2)
            {
                spriteRenderer.color = flashColor;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }
        
    }
    
}