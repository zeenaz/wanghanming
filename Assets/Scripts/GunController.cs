using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun currentGun;
    private float lastShotTime;

    private void Start()
    {
        lastShotTime = -currentGun.fireRate;
    }

    public void Shoot()
    {
        if (Time.time - lastShotTime >= currentGun.fireRate)
        {
            GameObject bullet = Instantiate(currentGun.bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().Initialize(transform.right); // Initialize the bullet with the gun's forward direction
            lastShotTime = Time.time;
        }
    }

    public void Reload()
    {
        // Implement reloading logic here
        Debug.Log("Reloading...");
    }
}
