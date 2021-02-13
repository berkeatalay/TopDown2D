using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float moveLimiter = 0.7f;

    Rigidbody2D rb2d = null;
    Animator animator = null;
    SpriteRenderer spriteRenderer = null;
    private float h;
    private float v;
    Vector2 nextPosition;
    public FloatingJoystick floatingJoystick;
    int layerMask;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        layerMask = LayerMask.GetMask("Interactibles");
    }

    private void Update()
    {
        HandleMovement();


    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 2f, layerMask);
            if (hit != null)
            {
                Debug.Log(hit.name);
            }
        }
    }

    private void HandleMovement()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(h) >= 0.7 && Mathf.Abs(v) >= 0.7)
        {
            h *= moveLimiter;
            v *= moveLimiter;
        }

        if (Mathf.Abs(h) >= 0.1 || Mathf.Abs(v) >= 0.1)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (h < -0.1)
        {
            spriteRenderer.flipX = true;
        }
        else if (h > 0.1)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(h * runSpeed, v * runSpeed);
    }


}
