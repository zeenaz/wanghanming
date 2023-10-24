using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlatformerPlayerMovementController playerController;

    private void Start()
    {
        playerController = transform.root.GetComponent<PlatformerPlayerMovementController>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Block"))
        {
            playerController.SetIsDownJumpGroundCheck(other.CompareTag("Ground"));

            if (playerController.Rigidbody.velocity.y <= 0)
            {
                playerController.IsGrounded = true;
                playerController.CurrentJumpCount = 0;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Block"))
        {
            playerController.IsGrounded = false;
        }
    }
}