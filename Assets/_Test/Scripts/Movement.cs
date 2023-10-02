using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [Space]
    [SerializeField] private LayerMask layerMask;

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
    }

    private void FixedUpdate()
    {
        rBody.velocity = PlayerInput();

        Jump();
    }

    private Vector2 PlayerInput()
    {
        return new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rBody.velocity.y);
    }

    private void Jump()
    {
        if (!CanJump()) return;

        Vector2 jump = new Vector2(rBody.velocity.x, Input.GetAxis("Jump") * jumpHeight);
        rBody.velocity = jump;
    }

    private bool CanJump() 
    {
        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y - 0.60f);
        if(Physics2D.CircleCast(checkPos, 0.5f, -transform.up, 0f, layerMask) && rBody.velocity.y < 0.1f)
        {
            return grounded = true;
        }
        return grounded = false;
    }

    private void OnDrawGizmos()
    {
        Vector2 checkPos = new Vector2(transform.position.x, transform.position.y - 0.60f);
        Gizmos.DrawSphere(checkPos, 0.5f);   
    }

}
