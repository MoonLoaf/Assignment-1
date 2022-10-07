using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private FloatVariable _turnTimer;
    
    [SerializeField]private Transform _attackPosition;
    [SerializeField] private float _range;
    [SerializeField]private float _damage;

    private bool _canAttack;

    private void Start()
    {
        _canAttack = true;
    }

    void Update()
    {
        MeleeInputs();
    }
    private void MeleeInputs()
    {
        if (_canAttack && Input.GetKeyDown(KeyCode.Q) && _turnTimer.Value > 0.35f)
        {
            Melee();
        }
    }
    private void Melee()
    {
        _turnTimer.ApplyChange(-0.35f);
        Collider[] hitColliders = Physics.OverlapSphere(_attackPosition.position, _range);

        _canAttack = false;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHP>().TakeDamage(_damage);
            }else{}
        }
        Invoke(nameof(ResetAttack), 2f);
    }
    private void ResetAttack()
    {
        _canAttack = true;
    }

}

