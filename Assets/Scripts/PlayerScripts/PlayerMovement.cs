using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private int _countJump = 1;

    private static int _leftMovementBool = Animator.StringToHash("LeftMovementBool");
    private static int _rightMovementBool = Animator.StringToHash("RightMovementBool");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool(_leftMovementBool, true);
        }
        else
        {
            _animator.SetBool(_leftMovementBool, false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool(_rightMovementBool, true);
        }
        else
        {
            _animator.SetBool(_rightMovementBool, false);
        }

        if (Input.GetKey(KeyCode.W) && _countJump == 1)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            _countJump = 0;
        }
    }

    public void RefreshJumps()
    {
        _countJump = 1;
    }
}
