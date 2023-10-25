using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMail : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    public bool IsOnExplosion = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", true);
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && IsOnExplosion)
            {
                playerHealth.OnExplosion();
            }
        }
    }
    
    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
    

    
    // when player hits this enemy and animation is started, player's HP - 1
}
