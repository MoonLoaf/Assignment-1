using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Ismoving", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Ismoving", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("MovingBack", true);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("MovingBack", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.W))
        {
            animator.SetBool("StandingJump", true);
        }
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.W))
        {
            animator.SetBool("StandingJump", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("RunningJump", true);
            Invoke("CancelJumpAnimation", 1f);
        }
    }
    private void CancelJumpAnimation()
    {
        animator.SetBool("RunningJump", false);
    }



}

