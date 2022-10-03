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
    [SerializeField]private TMP_Text _playerCountText;
    [SerializeField]private TMP_Text _characterCountText;

    private int _menuPlayerCount;
    private int _menuCharacterCount;
    
    
    public void PlayerIncrease()
    {
        _menuPlayerCount++;
        UpdateText();
    }
    public void PlayerDecrease()
    {
        _menuPlayerCount--;
        UpdateText();
    }
    
    public void characterIncrease()
    { 
        _menuCharacterCount++;
        UpdateText();
    }
    public void CharacterDecrease()
    {
        _menuCharacterCount--;
        UpdateText();
    }
    private void UpdateText()
    {
        _playerCountText.text = _menuPlayerCount.ToString();
        _characterCountText.text = _menuCharacterCount.ToString();
    }

}
