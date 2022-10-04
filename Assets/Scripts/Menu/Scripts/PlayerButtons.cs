using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PlayerButtons : MonoBehaviour
{
    [SerializeField]private TMP_Text _countText;

    [SerializeField] private IntVariable _intVariable;
    [SerializeField] private int _maxValue;
    [SerializeField] private int _minValue;


    private void Start()
    {
        UpdatePlayerText();
    }

    public void CountIncrease()
    {
        _intVariable.ApplyChange(+1);

        if (_intVariable.Value >= _maxValue)
        {
            _intVariable.Value = _maxValue;
        }

        UpdatePlayerText();
    }
    public void CountDecrease()
    {
        _intVariable.ApplyChange(-1);
        
        if (_intVariable.Value <= _minValue)
        {
            _intVariable.Value = _minValue;
        }
        UpdatePlayerText();
    }
    
    private void UpdatePlayerText()
    {
        _countText.text = _intVariable.Value.ToString();
    }

}
