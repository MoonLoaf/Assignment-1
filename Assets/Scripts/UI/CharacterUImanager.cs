using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterUImanager : MonoBehaviour
{
    CharacterManager characterManager;
    private TMP_Text teamText;

    private void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        
    }
    public void init()
    {
        foreach (GameObject playerCharacter in characterManager.Team1)
        {
            teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            teamText.text = "Team 1";
        }
        foreach (GameObject playerCharacter in characterManager.Team2)
        {
            teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            teamText.text = "Team 2";
        }
        foreach (GameObject playerCharacter in characterManager.Team3)
        {
            teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            teamText.text = "Team 3";
        }
        foreach (GameObject playerCharacter in characterManager.Team4)
        {
            teamText = playerCharacter.GetComponentInChildren<TMP_Text>();
            teamText.text = "Team 4";
        }
    }
}
