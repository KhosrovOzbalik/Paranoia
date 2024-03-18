using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool jumpInput;

    public AudioSource jump_sound;

    private Rigidbody2D rb;
    private Transform transform;
    private Animator animator;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jumpInput = true;
        }
        
        
        // Flip
        if (moveInput > 0) transform.localScale = Vector3.one;
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FixedUpdate()
    {
        if (jumpInput && isGrounded())
        {
            Jump();
            
        }
        else if (moveInput != 0)
        {
            Move();
        }
        else if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        
            
    }
    private void Jump()
    {
        jump_sound.Play();
        rb.velocity = Vector2.up * jumpForce;
        animator.SetTrigger("jump");
        jumpInput = false;
    }

    private void Move()
    {
        if (isGrounded())
        {
            CreateDust();
        }
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetBool("isRunning", true);
    }

    public bool isGrounded()
    {
        
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, checkRadius);
    }

    private void CreateDust()
    {
        dust.Play();
    }
}
