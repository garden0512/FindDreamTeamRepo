using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float inputValueX;
    [SerializeField] float inputValueY;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _lastMoveDirection;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isJumping = false;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lastMoveDirection = Vector2.left;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;
        }
        else
        {
            speed = 2f;
        }
        _rigidbody2D.linearVelocityX = inputValueX * speed;
        if (inputValueX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (inputValueX < 0)
        {
            _spriteRenderer.flipX = true;
        }

        Vector2 moveVector = new Vector2(inputValueX, 0f);

        if (moveVector != Vector2.zero)
        {
            _lastMoveDirection = moveVector.normalized;
        }
        bool isMoving = Mathf.Abs(inputValueX) > 0.01f;
        bool isRunning = isMoving && Keyboard.current.leftShiftKey.isPressed;
        _animator.SetBool("isMove", isMoving);
        _animator.SetBool("isRun", isRunning);
    }

    private void OnMove(InputValue value)
    {
        inputValueX = value.Get<Vector2>().x;
    }

    private void OnJump(InputValue value)
    {
        if (_isJumping==false)
        {
            _isJumping = true;
            _rigidbody2D.AddForce(new Vector2(inputValueX, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }
    }
}
