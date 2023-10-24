using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementPlatformer playerMovement;
    private PlayerHealth playerHealth;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovementPlatformer>();
        playerHealth = GetComponent<PlayerHealth>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovementPlatformer component not found on " + gameObject.name);
        }
    }

    private void Update()
    {
        UpdateAnimationStates();
    }

    private void UpdateAnimationStates()
    {
        if (playerMovement == null || animator == null) return;

        animator.SetFloat("Speed", Mathf.Abs(playerMovement.rb.velocity.x));
        animator.SetBool("IsGrounded", playerMovement.isGrounded && playerMovement.rb.velocity.y <= 0);
        animator.SetBool("IsJumping", playerMovement.rb.velocity.y > 0);
        animator.SetBool("Shoot", Input.GetKey(KeyCode.Mouse0));
        animator.SetBool("Die", playerHealth.currentHealth <= 0 || Input.GetKey(KeyCode.P));
    }

}