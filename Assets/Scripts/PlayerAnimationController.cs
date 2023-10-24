using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private PlatformerPlayerMovementController movementController;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        movementController = GetComponent<PlatformerPlayerMovementController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.Play("Attack");
        }
        if (Input.GetKey(KeyCode.P))
        {
            anim.Play("Die");
        }
        if (Mathf.Approximately(movementController.CurrentJumpCount, 0) && movementController.IsGrounded)
        {
            anim.Play("Idle");
        }
        if (!Mathf.Approximately(rb.velocity.x, 0))
        {
            anim.Play("Run");
        }
        else if (movementController.IsGrounded && movementController.CurrentJumpCount > 0)
        {
            anim.Play("Jump");
        }
        
    }
}