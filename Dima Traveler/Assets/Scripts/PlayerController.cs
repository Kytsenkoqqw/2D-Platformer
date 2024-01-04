using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerTransform = transform;
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f) * _speed;
        _rb.velocity = new Vector2(movement.x, _rb.velocity.y);

        if (horizontalInput < 0)
        {
            _playerTransform.localScale = new Vector3(-1,1,1);
        }
        else if (horizontalInput > 0)
        {
            _playerTransform.localScale = new Vector3(1,1,1);
        }

        if (_isGrounded && Input.GetKey(KeyCode.W))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.y, _jumpForce);
    }
}
