using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private Animator animator;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float jumpGravity = 5;
    [SerializeField] private int maxJumps = 1;
    //[SerializeField] private KeyCode jumpkeyCode = KeyCode.Space;

    private Ground ground = null;
    private float baseGravityScale;
    private const int noJump = 0, jumpRise = 1, jumpFall = 2;
    private int jumps = 0;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ground = GetComponentInChildren<Ground>();
        baseGravityScale = rbody2D.gravityScale;
    }

    private bool doJump = false;
    private void Update()
    {
        // doJump |= (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"));
        //doJump |= Input.GetKeyDown(KeyCode.Space) && ground.IsGrounded() && jumps < maxJumps;
        doJump |= Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps;
    }

    private void FixedUpdate()
    {
        Vector2 motion = rbody2D.velocity;
        if (doJump)
        {
            doJump = false;
            motion.y = jumpForce;
            rbody2D.gravityScale = jumpGravity;
            animator.SetInteger("jumpState", jumpRise);
            jumps++;
        }
        if (ground.IsGrounded() == false)
        {
            rbody2D.gravityScale = jumpGravity;
            animator.SetInteger("jumpState", jumpFall);
        }
        if (ground.IsGrounded() == true)
        {
            rbody2D.gravityScale = baseGravityScale;
            animator.SetInteger("jumpState", noJump);
            jumps = 0;
        }

        var input = Input.GetAxis("Horizontal");
        if (input == 0)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(input);
            transform.localScale = scale;
        }
        animator.SetBool("IsWalk", input != 0);
        print(input);
        motion.x = input * maxSpeed;


        rbody2D.velocity = motion;
    }
}
