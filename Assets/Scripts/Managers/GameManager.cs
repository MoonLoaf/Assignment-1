using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private VoidEvent _onGameStart;

    [Header("Main Menu Settings")]

    [Range(1, 4)]
    public int playerCount;

    [Range(1, 6)]
    public int characterPerPlayer;

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
