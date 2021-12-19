using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_AI : MonoBehaviour
{
    #region Variables
    public Transform aggroAreaTLC;
    public Transform aggroAreaBRC;
    public Transform rightCheck, groundCheck;
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject player;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float speed, maxSpeed, circleRadius, jumpForce, attackCap;
    private float attackCD;
    private bool facingRight = true, righttouch, groundTouch, aggro, attacking;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
        if (rb.velocity.x < maxSpeed && facingRight)
        {
            rb.AddForce(transform.right * speed);
        }

        if (rb.velocity.x > -maxSpeed && !facingRight)
        {
            rb.AddForce(transform.right * speed);
        }

        if (attackCD <= 0)
        {
            attackCD = 0;
        }

        attackCD -= 1 * Time.deltaTime;

        HitDetection();


        if(aggro && attackCD <= 0)
        {
            anim.SetBool("nearPlayer", true);
            attacking = true;
            attackCD = attackCap;
        }
        if(!aggro)
        {
            anim.SetBool("nearPlayer", false);
        }

        if (attacking && facingRight)
        {
            rb.AddForce(transform.up * jumpForce);
            rb.AddForce(transform.right * jumpForce * 2);
            attacking = false;
        }
        if (attacking && !facingRight)
        {
            rb.AddForce(transform.up * jumpForce);
            rb.AddForce(transform.right * jumpForce * 2);
            attacking = false;
        }
    }

    void HitDetection()
    {
        righttouch = Physics2D.OverlapCircle(rightCheck.position, circleRadius, groundLayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLayer);
        aggro = Physics2D.OverlapArea(aggroAreaTLC.position, aggroAreaBRC.position, playerLayer);

        HitLogic();
    }

    void HitLogic()
    {
        if (righttouch && facingRight)
        {
            Flip();
        }
        else if (righttouch && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.position, circleRadius);
        Gizmos.DrawWireSphere(groundCheck.position, circleRadius);
    }

    
}