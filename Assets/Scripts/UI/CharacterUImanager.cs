using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterUImanager : MonoBehaviour
{
    [SerializeField] private CharacterManager _characterManager;
    private TMP_Text _teamText;

    private void Start()
    {
        _characterManager = _characterManager.GetComponent<CharacterManager>();
        
    }
    public void init()
    {
        foreach (GameObject playerCharacter in _characterManager.Team1)
        {
            _teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            _teamText.text = "Team 1";
        }
        foreach (GameObject playerCharacter in _characterManager.Team2)
        {
            _teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            _teamText.text = "Team 2";
        }
        foreach (GameObject playerCharacter in _characterManager.Team3)
        {
            _teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            _teamText.text = "Team 3";
        }
        foreach (GameObject playerCharacter in _characterManager.Team4)
        {
            _teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            _teamText.text = "Team 4";
        }
    }
}
