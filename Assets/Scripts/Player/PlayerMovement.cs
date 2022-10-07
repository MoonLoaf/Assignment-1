using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FloatVariable _turnTimer;
    
    private float _speed;
    private float _xMovement;
    private float _zMovement;

    private float _actionCost;
    
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 velocity;
    [SerializeField]private bool _isGrounded;

    private void Update()
    {
        if(_turnTimer.Value > 0 && GameManager.InputEnabled)
        {
            MovementInputs();
        }
        if(_xMovement != 0 || _zMovement != 0)
        {
            _turnTimer.ApplyChange(-_actionCost * Time.deltaTime);
        }
    }
    private void MovementInputs()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _zMovement = Input.GetAxis("Vertical");
        
        Vector3 Movement = transform.right * _xMovement + transform.forward * _zMovement;
        
        _controller.Move(Movement * (_speed * Time.deltaTime));
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 8f;
            _actionCost = 0.16f;
        }
        else
        {
            _speed = 5f;
            _actionCost = 0.1f;
        }
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        
        if (_isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            _gravity = -10f;
        }
        if (Input.GetKey(KeyCode.Space) && _isGrounded && _turnTimer.Value != 0 && GameManager.InputEnabled)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        velocity.y += _gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }
}

