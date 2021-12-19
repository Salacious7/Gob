using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_AI : MonoBehaviour
{
    #region Variables
    public float speed;
    private Animator anim;
    Rigidbody2D rb;
    private Transform player;
    public bool preparing;
    public float prepareLength;
    public float prepareCounter;
    public float aggroRadius;
    public LayerMask playerLayer;
    private RaycastHit2D aggro;
    private Vector2 target;
    public float attackCD;
    public float attackCounter;
    private bool collided = false;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        prepareCounter = prepareLength;
        attackCounter = 0;
    }

    void Update()
    {
        if(collided)
        {
            attackCounter -= 1f * Time.deltaTime;    
        }
        if(attackCounter <= 0)
        {
            attackCounter = 0;
        }
        if(AggroCheck() && attackCounter <= 0)
        {
            attackCounter = attackCD;
            Prepare(aggro);
        }

        if (preparing)
        {
            prepareCounter -= 1f * Time.deltaTime;
        }

        if (prepareCounter <= 0)
        {
            Attack();
        }

        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if the bat collides with the wall after attacking
        //anim.SetBool("hasGravity", true);

    }

    void Attack()
    {
        transform.right = -target;
        anim.SetTrigger("attack");
        rb.velocity = target * speed * Time.deltaTime;
    }

    void Prepare(RaycastHit2D hit)
    {
        target = (hit.transform.position - transform.position).normalized;
        prepareCounter = prepareLength;
        preparing = true;
        anim.SetTrigger("prepare");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRadius);
    }

    bool AggroCheck()
    {
        aggro = Physics2D.CircleCast(transform.position, aggroRadius, transform.position, 0, playerLayer);
        return aggro;
    }
}
