using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    private Pistol _pistol;
    private TeamHP _teamHP;
    [SerializeField] private GameObject _pistolObject;
    [SerializeField] private GameObject Cross;

    private  float _maxHP = 100;
    private float _currentHP;
    public bool IsDead;
    [SerializeField]private TMP_Text _HPtext;

    void Start()
    {
        IsDead = false;
        _currentHP = _maxHP;
        _pistol = GetComponent<Pistol>();
        _teamHP = FindObjectOfType<TeamHP>().GetComponent<TeamHP>();
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
        Instantiate(Cross, transform.position, Quaternion.identity);
        Destroy(_pistolObject);
        
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Canvas>().enabled = false;

        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Pistol>().enabled = false;
        
        _teamHP.UpdateTeamCount();
    }
}
