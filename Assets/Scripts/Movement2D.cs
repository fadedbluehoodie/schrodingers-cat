using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float slideSpeed = 20f;
    public float slideDuration = 1.0f; // Adjust the slide duration.
    public float slideCooldown = 1.0f;
    public bool isGrounded;

    private bool isSliding = false;
    private float slideTimer = 0f;

    private SpriteRenderer sprite;
    private Animator animator;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        SlideInput();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (moveInput > 0)
        {
            sprite.flipX = false;
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true;
        }

        // Update the Animator's "IsRunning" parameter based on player input.
        animator.SetBool("IsRunning", Mathf.Abs(moveInput) > 0);

        if (isSliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer >= slideDuration)
            {
                EndSlide();
            }
        }

        // Update the Animator's "IsSliding" parameter based on "isSliding."
        animator.SetBool("IsSliding", isSliding);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }
    }

    private void SlideInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && animator.GetBool("IsRunning"))
        {
            StartSlide();
        }
    }

    private void StartSlide()
    {
        isSliding = true;
        slideTimer = 0f;
    }

    private void EndSlide()
    {
        isSliding = false;
        slideTimer = 0f;
    }
}
