using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecover : MonoBehaviour
{
    public int healthRecover = 1;
    public GameObject healthRecoverEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().RecoverHealth(healthRecover);
            Instantiate(healthRecoverEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
