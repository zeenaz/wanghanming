using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private Transform playerTransform;
    public float speed = 1f;
    public float lifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        MoveToPlayer();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", true);
            playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.OnExplosion();
        }
    }
    
    public void MoveToPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //move to player position
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
    
    //Destory itself after lifeTime
    private void OnEnable()
    {
        Invoke("Destroy", lifeTime);
    }
    
    private void OnDisable()
    {
        CancelInvoke();
    }
    
    private void Destroy()
    {
        animator.SetBool("IsAttack", true);
    }
}
