using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHP : MonoBehaviour
{
    private CharacterManager _characterManager;

    private int _team1DeathCount;
    private int _team2DeathCount;
    private int _team3DeathCount;
    private int _team4DeathCount;

    private bool _team1Dead;
    private bool _team2Dead;
    private bool _team3Dead;
    private bool _team4Dead;
   
   void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
    }
    public void CheckTeamDeath()
    {
        foreach (GameObject playerCharacter in _characterManager.Team1)
        {
            if (playerCharacter.GetComponent<PlayerHP>().IsDead)
            {
                _team1DeathCount++;
            }
        }

        if (_team1DeathCount == _characterManager.Team1.Count)
        {
            _team1Dead = true;
        }
        else
        {
            _team1Dead = false;
            _team1DeathCount = 0;
        }
    }
}
