using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    public float lifeTime = 5f;
    
    public Rigidbody2D rb;
    
    public GameObject impactEffect;
    

    /*public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized;
    }*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletTarget target = collision.gameObject.GetComponent<BulletTarget>();
        if (target != null)
        {
            target.TakeDamage();
            
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(gameObject);
        //Debug.Log("Bullet collided with " + collision.gameObject.name + "!");
    }
    
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
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}