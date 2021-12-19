using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
   

    public void TakeDamage (int damage)
    {
        health -= damage;
        MultiplyAtDeath babyMaker = gameObject.GetComponent<MultiplyAtDeath>();
        if (health <= 0 && babyMaker != null)
        {
            babyMaker.deathMultiplication();
        }
        else if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
