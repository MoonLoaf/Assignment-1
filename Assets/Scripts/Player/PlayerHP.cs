using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    private int _maxHP = 85;
    private int _currentHP;
    [SerializeField]private TMP_Text _HPtext;

    void Start()
    {
        _currentHP = _maxHP;
    }
    public void SetHP()
    {
        _HPtext.text = "HP: " + _currentHP.ToString();
    }

    void Update()
    {
        SetHP();
    }
    public void TakeDamage()
    {
        
    }
}
