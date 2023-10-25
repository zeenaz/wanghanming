using UnityEngine;

public class PlayerMovementPlatformer : Z_Player
{
    public Transform EyeTransform;
    private PlayerHealth playerHealth;
    public bool isFacingRight = true;

    protected override void Awake()
    {
        base.Awake();
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component not found on " + gameObject.name);
        }
    }

    protected override void Update()
    {
        base.Update();
        RotateTowardsMouse();
    }

    protected override void Move(float horizontalInput)
    {
        base.Move(horizontalInput);

        if (horizontalInput > 0)
        {
            Flip(false);
            isFacingRight = true;
        }
        else if (horizontalInput < 0)
        {
            Flip(true);
            isFacingRight = false;
        }
    }

    protected void Flip(bool isFacingRight)
    {
        transform.localScale = new Vector3(isFacingRight ? -1 : 1, 1, 1);
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - EyeTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        EyeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
    public Vector2 GetDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - EyeTransform.position;
        return direction;
    }
}

