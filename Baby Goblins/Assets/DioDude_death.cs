using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioDude_death : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public GameObject diodites;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            onDth();
        }
    }

    void onDth()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(diodites, gameObject.transform.position, Quaternion.identity);
        death();
    }

    void death()
    {
        Destroy(gameObject);
    }
}

