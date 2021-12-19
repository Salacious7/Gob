using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyAtDeath : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject babies;

    public void deathMultiplication()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(babies, gameObject.transform.position, Quaternion.identity);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
