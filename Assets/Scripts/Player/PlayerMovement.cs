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
    
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;

    Vector3 velocity;
    [SerializeField]private bool _isGrounded;

    //GOONS

    [SerializeField] private GameObject RPG;
    [SerializeField] private GameObject Shotgun;
    [SerializeField] private GameObject Rifle;


    //========================================================================================================================\\
    private void Awake()
    {
    }

    private void Start()
    {
        //SetActiveWeapon(0);
    }

    private void Update()
    {
        if (_turnTimer.Value > 0)
        {
            MovementInputs();
        }
        if (_xMovement != 0 || _zMovement != 0)
        {
            _turnTimer.ApplyChange(-0.05f * Time.deltaTime);
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
        }
        else { _speed = 5f; }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        
        if (_isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            _gravity = -10f;
        }
        if (Input.GetKey(KeyCode.Space) && _isGrounded && _turnTimer.Value != 0)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        velocity.y += _gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }

    /*public void SetActiveWeapon(int weaponIndex)
    {
        if (weaponIndex == 1)
        {
            RPG.gameObject.SetActive(true);
            Shotgun.gameObject.SetActive(false);
            Rifle.gameObject.SetActive(false);
        }
        else if (weaponIndex == 2)
        {
            Shotgun.gameObject.SetActive(true);
            RPG.gameObject.SetActive(false);
            Rifle.gameObject.SetActive(false);
        }
        else if (weaponIndex == 3)
        {
            Rifle.gameObject.SetActive(true);
            Shotgun.gameObject.SetActive(false);
            RPG.gameObject.SetActive(false);
        }
        else if (weaponIndex == 0)
        {
            Rifle.gameObject.SetActive(false);
            Shotgun.gameObject.SetActive(false);
            RPG.gameObject.SetActive(false);
        }
    }*/
    
}

