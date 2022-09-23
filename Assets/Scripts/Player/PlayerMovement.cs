using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    private float _speed;
    public float gravity;
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
        Movement();
    }
    private void Movement()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 8f;
        }
        else { _speed = 5f; }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        if (_isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            gravity = -10f;
        }
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
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

