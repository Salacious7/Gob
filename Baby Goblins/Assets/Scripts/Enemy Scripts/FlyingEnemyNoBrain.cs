using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyNoBrain : MonoBehaviour
{
    public float speed, circleRadius;

    private Rigidbody2D rb;
    public GameObject rightCheck, leftCheck, roofCheck, groundCheck;
    public LayerMask groundLayer;
    private bool facingRight = true, groundTouch, roofTouch, rightTouch, leftTouch;
    public float dirX = 1, dirY = 0.25f;

    //adding and changing things to impulse

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);
        Vector2 startDir = new Vector2(x, y);
        rb.AddForce(startDir, ForceMode2D.Impulse);
    }

    void Update()
    {

        //rb.velocity = new Vector2(dirX, dirY) * speed * Time.deltaTime;
        HitDetection();

    }

    void HitDetection()
    {
        rightTouch = Physics2D.OverlapCircle(rightCheck.transform.position, circleRadius, groundLayer);
        leftTouch = Physics2D.OverlapCircle(leftCheck.transform.position, circleRadius, groundLayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, circleRadius, groundLayer);
        
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
    
        HitLogic();
    }

    void HitLogic()
    {
        Vector2 newDir = new Vector2(dirX, dirY) * speed * Time.deltaTime;
        if (rightTouch && facingRight)
        {
            Flip();
            rb.AddForce(newDir, ForceMode2D.Impulse);
        }
        else if (rightTouch && !facingRight)
        {
            Flip();
            rb.AddForce(newDir, ForceMode2D.Impulse);
        }
        if (roofTouch)
        {
            dirY = -0.25f;
            rb.AddForce(newDir, ForceMode2D.Impulse);
        }
        else if (groundTouch)
        {
            dirY = 0.25f;
            rb.AddForce(newDir, ForceMode2D.Impulse);
        }
        if (leftTouch)
        {
            rb.AddForce(newDir, ForceMode2D.Impulse);
        }


    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        dirX = -dirX;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(roofCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(leftCheck.transform.position, circleRadius);
    }
}
