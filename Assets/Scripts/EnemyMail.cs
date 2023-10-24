using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMail : MonoBehaviour
{
    private Collider2D collider;
    private Animator animator;
    private PlayerHealth playerHealth;
    public bool IsOnExplosion = false;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponentInChildren<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth = other.GetComponent<PlayerHealth>();
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerHealth != null && IsOnExplosion)
        {
            playerHealth.OnExplosion();
        }
    }
    
    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
    

    
    // when player hits this enemy and animation is started, player's HP - 1
}
