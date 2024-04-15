using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashControll : MonoBehaviour
{
    [Header("Dash Var")]
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    
    
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;

    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;

    private InputHandler inputHandler;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var dashInput = inputHandler.IsDashKey;
        if (dashInput && _canDash && this.GetComponent<PlayerController>().canMove)
        {
            anim.SetTrigger("isDash");

            _isDashing = true;
            _canDash = false;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0f);
            }
            StartCoroutine(StopDashing());
        }
        if (_isDashing)
        {
            rb.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }
        if (PlayerController.Instance.IsGrounded())
        {
            _canDash = true;
        }
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _isDashing = false;
        rb.velocity = Vector2.zero;
    }
}
