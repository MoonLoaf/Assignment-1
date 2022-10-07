using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    private Pistol _pistol;
    private TeamDeathCheck _teamDeathCheck;
    
    [SerializeField] private GameObject _pistolObject;
    [SerializeField] private GameObject _knifeObject;
    [SerializeField] private GameObject _cross;

    private  float _maxHP = 100;
    private float _currentHP;
    public bool IsDead;
    [SerializeField]private TMP_Text _HPtext;

    void Start()
    {
        IsDead = false;
        _currentHP = _maxHP;
        _pistol = GetComponent<Pistol>();
        _teamDeathCheck = FindObjectOfType<TeamDeathCheck>().GetComponent<TeamDeathCheck>();
    }
    private void SetHP()
    {
        _HPtext.text = $"HP: {_currentHP:N0}";
    }
    void Update()
    {
        SetHP();
    }
    public void TakeDamage(float damage)
    {
        if (damage >= 20)
        {
            damage = 20;
        }
        _currentHP -= damage;
        
        if(_currentHP <= 0)
        {
            _currentHP = 0;
            
            PlayerDead();
        }

        SetHP();
    }
    private void PlayerDead()
    {
        IsDead = true;
        Instantiate(_cross, transform.position, Quaternion.identity);
        Destroy(_pistolObject);
        
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Canvas>().enabled = false;

        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Pistol>().enabled = false;
        gameObject.GetComponent<MeleeAttack>().enabled = false;
        
        _teamDeathCheck.CheckTeamDeath();
        _teamDeathCheck.CheckWin();
    }
}
