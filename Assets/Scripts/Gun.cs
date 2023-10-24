using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public int ammoCapacity;
    public float fireRate;
    public GameObject bulletPrefab;
}
