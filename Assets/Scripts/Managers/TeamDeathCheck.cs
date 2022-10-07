using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class TeamDeathCheck : MonoBehaviour
{
    private CharacterManager _characterManager;
    private GameManager _gameManager;

    [SerializeField] private bool _team1Dead;
    [SerializeField] private bool _team2Dead;
    [SerializeField] private bool _team3Dead;
    [SerializeField] private bool _team4Dead;

    [SerializeField] private TMP_Text _winText;

   void Start()
   {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        _winText.enabled = false;

        if (_characterManager.teamArray.Length == 2)
        {
            _team3Dead = true;
            _team4Dead = true;
        }
        if (_characterManager.teamArray.Length == 3)
        {
            _team4Dead = true;
        }
    }
    public void CheckTeamDeath()
    {
        for (int i = 0; i < _characterManager.teamArray.Length; i++)
        {
            bool teamDead = _characterManager.teamArray[i].TrueForAll(playerCharacter => playerCharacter.GetComponent<PlayerHP>().IsDead);
            if (teamDead)
            {
                SetCorrectTeam(i);
            }
        }
    }
    private void SetCorrectTeam(int intindex)
    {
        switch (intindex)
        {
            case 0:
                _team1Dead = true;
                break;
            case 1:
                _team2Dead = true;
                break;
            case 2:
                _team3Dead = true;
                break;
            case 3:
                _team4Dead = true;
                break;
            
            default:
                break;
        }
    }
    public void CheckWin()
    {
        if (!_team1Dead && _team2Dead && _team3Dead && _team4Dead)
        {
            GameManager.InputEnabled = false;
            _winText.enabled = true;
            _winText.text = "Team 1 Wins";
        }
        if (_team1Dead && !_team2Dead && _team3Dead && _team4Dead)
        {
            GameManager.InputEnabled = false;
            _winText.enabled = true;
            _winText.text = "Team 2 Wins";
        }
        if (!_team1Dead && _team2Dead && !_team3Dead && _team4Dead)
        {
            GameManager.InputEnabled = false;
            _winText.enabled = true;
            _winText.text = "Team 3 Wins";
        }
        if (!_team1Dead && _team2Dead && _team3Dead && !_team4Dead)
        {
            GameManager.InputEnabled = false;
            _winText.enabled = true;
            _winText.text = "Team 4 Wins";
        }
    }
}

