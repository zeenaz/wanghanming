using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    [Tooltip("Bullets per clip")]
    public int ammoCapacity;
    [Tooltip("Bullets per second")]
    public float fireRate;
    [Tooltip("Bullets type")]
    public GameObject bulletPrefab;
}
