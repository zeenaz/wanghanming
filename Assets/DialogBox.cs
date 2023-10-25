using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private Transform playerTransform;
    public float speed = 0.1f;

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
            MoveToPlayer();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.OnExplosion();
        }
    }
    
    private void MoveToPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed);
    }
}
