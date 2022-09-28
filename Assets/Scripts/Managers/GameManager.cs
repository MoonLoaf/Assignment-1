using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private VoidEvent _onGameStart;

    [Header("Main Menu Settings")]

    [SerializeField, Range(2, 4)]
    public int playerCount;

    [SerializeField, Range(1, 6)]
    private int characterPerPlayer;

    public int CharacterPerPlayer { get => characterPerPlayer; }

    private void StartGame()
    {
        _onGameStart.Raise();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartGame();
        }
    }

}
