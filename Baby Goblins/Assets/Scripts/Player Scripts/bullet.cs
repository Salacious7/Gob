using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject afterEffect;
    public ParticleEffect particle;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Instantiate(afterEffect, transform.position, transform.rotation);
        particle.FuckOff();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
      
        Instantiate(afterEffect, transform.position, transform.rotation);
        particle.FuckOff();
        Destroy(gameObject);
    }



}
