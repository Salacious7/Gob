using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Rigidbody2D rb;
    public float runSpeed = 40f;
    public Animator animator;

    float horizontalMove = 0f;
    
    public float jumpTimeCounter;
    public float jumpTime;
	bool _isJumping;
    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //detect input from player
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && controller.m_Grounded)
        {
            jump = true;
        }
        //trying to bandaid a jump time counter

        jumpTimeCounter -= Time.deltaTime;

        if(jumpTimeCounter <= 0)
        {
            jumpTimeCounter = 0;
        }
        if (Input.GetButton("Jump"))
        {
            if(jump)
            {
                jumpTimeCounter = jumpTime;
                jump = false;
            }
            if (jumpTimeCounter > 0)
            {
                _isJumping = true;
                animator.SetBool("IsJumping", true);
            }
            else if(jumpTimeCounter == 0)
            {
                _isJumping = false;
                animator.SetBool("IsJumping", false);
            }
        
        }
        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
            animator.SetBool("IsJumping", false);
        }
        // end of bandaid jump test
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    
        if (rb.velocity.y < 0) 
        {
            animator.SetBool("IsFalling", true); 
        } 
        else 
        {
            animator.SetBool("IsFalling", false);
        }
    }
    public void OnLanding() 
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }

    private void FixedUpdate() 
    {
        // apply input to move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, _isJumping);
        //jump = false;
    }
}
