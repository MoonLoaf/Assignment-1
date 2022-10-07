using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    private Vector3 _attackPosition;
    [SerializeField] private float _range;
    [SerializeField]private float _damage;

    void Update()
    {
        MeleeInputs();
    }
    private void MeleeInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Melee();
        }
    }
    private void Melee()
    {
        UpdateAttackPosition();
        Collider[] hitColliders = Physics.OverlapSphere(_attackPosition, _range - 0.2f);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHP>().TakeDamage(_damage);
            }else{}
        }
    }
    private void UpdateAttackPosition()
    {
        _attackPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _range);
    }
}

