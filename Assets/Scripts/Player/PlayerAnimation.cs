using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private FloatVariable _turnTimer;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && _turnTimer.Value != 0 && GameManager.InputEnabled)
        {
            _animator.SetBool("Ismoving", true);
        }
        if (!Input.GetKey(KeyCode.W) || _turnTimer.Value == 0)
        {
            _animator.SetBool("Ismoving", false);
        }


        if (Input.GetKey(KeyCode.S) && _turnTimer.Value != 0 && GameManager.InputEnabled)
        {
            _animator.SetBool("MovingBack", true);
        }
        if (!Input.GetKey(KeyCode.S) || _turnTimer.Value == 0)
        {
            _animator.SetBool("MovingBack", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.W) && _turnTimer.Value != 0 && GameManager.InputEnabled)
        {
            _animator.SetBool("StandingJump", true);
        }
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("StandingJump", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            _animator.SetBool("IsAiming", true);
        }
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            _animator.SetBool("IsAiming", false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetTrigger("Melee");
            
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && _turnTimer.Value != 0 && GameManager.InputEnabled)
        {
            _animator.SetBool("RunningJump", true);
            Invoke("CancelJumpAnimation", 1f);
        }
    }
    private void CancelJumpAnimation()
    {
        _animator.SetBool("RunningJump", false);
    }
    



}

