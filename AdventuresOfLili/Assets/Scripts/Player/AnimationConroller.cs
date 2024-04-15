using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConroller : MonoBehaviour
{
    public enum Moves {idle, run, jumpUp, jumpDown }
    private Moves currentMove;

    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();

        float moveInput = Input.GetAxisRaw("Horizontal");
        FlipCharacter(moveInput);

        if (Mathf.Abs( moveInput)<0.2)
        {
            currentMove = Moves.idle;
        }
        if (Mathf.Abs(moveInput) >= 0.2)
        {
            currentMove = Moves.run;
        }
        if (rb.velocity.y>.1f)
        {
            currentMove = Moves.jumpUp;
        }
        if (rb.velocity.y < -.2f)
        {
            currentMove = Moves.jumpDown;
        }
        anim.SetInteger("AnimContInt", (int)currentMove);


    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    void FlipCharacter(float moveInput)
    {
        if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
        else if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
    }
}
