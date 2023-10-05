using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [Space]
    [SerializeField] private LayerMask layerMask;
    [Space]
    [SerializeField] private Transform spriteRunTransform;
    [SerializeField] private Transform spriteIdleTransform;
    [SerializeField] private Transform spriteJumpTransform;
    private float dir = 1;
    private Animator animator;

    public bool isGrounded
    {
        get
        {
            return grounded;
        }
    }

    private bool grounded;
    Rigidbody2D rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = spriteJumpTransform.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rBody.velocity = PlayerInput();

        if (PlayerInput().x > 0)
            dir = 1;
        else if (PlayerInput().x < 0)
            dir = -1;

        if (PlayerInput().x != 0 && CanJump())
        {
            spriteRunTransform.gameObject.SetActive(true);
            spriteIdleTransform.gameObject.SetActive(false);
            spriteJumpTransform.gameObject.SetActive(false);

            spriteRunTransform.localScale = new Vector3(0.1f * dir, 0.1f, spriteRunTransform.localScale.z);
        }
        else
        {
            if (CanJump()) 
            {
                spriteRunTransform.gameObject.SetActive(false);
                spriteIdleTransform.gameObject.SetActive(true);
                spriteJumpTransform.gameObject.SetActive(false);
            }
            else if(!CanJump() && Input.GetAxis("Jump") != 0)
            {
                spriteJumpTransform.gameObject.SetActive(true);
                spriteRunTransform.gameObject.SetActive(false);
                spriteIdleTransform.gameObject.SetActive(false);
            }

            spriteIdleTransform.localScale = new Vector3(5f * dir, 5f, 1f);
            spriteJumpTransform.localScale = new Vector3(5f * dir, 5f, 1f);
        }

        Jump();
    }

    private Vector2 PlayerInput()
    {
        return new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rBody.velocity.y);
    }

    private void Jump()
    {
        if (!CanJump())
        {          
            return;
        }
      
        Vector2 jump = new Vector2(rBody.velocity.x, Input.GetAxis("Jump") * jumpHeight);
        rBody.velocity = jump;
    }

    private bool CanJump() 
    {
        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y - 0.60f);
        if (Physics2D.CircleCast(checkPos, 0.5f, -transform.up, 0f, layerMask) && rBody.velocity.y < 0.1f)
        {
            animator.ResetTrigger("Jump");
            return grounded = true;
        }
        else
        {
            animator.SetTrigger("Jump");
            return grounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y - 0.60f);
        Gizmos.DrawSphere(checkPos, 0.5f);   
    }

}
