using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobRangedAttack1 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public float AttackInterval = 1; //time between attacks in seconds
    private float elapsedTime = 0;

    Vector3 mousePos;
    float lookAngle;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - firePoint.position;
        lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);


        if (Input.GetButton("Fire1"))
        {
            if (Time.time > elapsedTime)
            {
                animator.SetBool("IsAttacking", true);
                Shoot();//created function
                elapsedTime = Time.time + AttackInterval;
            }

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsAttacking", false);
        }


    }

    void Shoot() //function to be called that was created
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}