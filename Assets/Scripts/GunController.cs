using UnityEngine;
using UnityEngine.Serialization;

public class GunController : MonoBehaviour
{
    public Gun currentGun;
    private float lastShotTime;
    public Transform offSet;
    private PlayerMovementPlatformer playerMovement;
    private bool isFacingRight;

    private void Start()
    {
        lastShotTime = -currentGun.fireRate;
        playerMovement = GetComponent<PlayerMovementPlatformer>();
        
    }

    public void Shoot()
    {
        if (Time.time - lastShotTime >= currentGun.fireRate)
        {
            isFacingRight = playerMovement.isFacingRight;
            if (!isFacingRight) // if player is facing left
            {
                Instantiate(currentGun.bulletPrefab, offSet.position, Quaternion.Euler(0, 0, 180));
            }
            else
            {
                Instantiate(currentGun.bulletPrefab, offSet.position, offSet.rotation);
            }
            
            
            lastShotTime = Time.time;
        }
    }

    public void Reload()
    {
        // Implement reloading logic here
        Debug.Log("Reloading...");
    }
}
