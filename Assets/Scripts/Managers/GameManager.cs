using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private VoidEvent _onGameStart;

    [Header("Main Menu Settings")]

    public IntVariable playerCount;

    [SerializeField] private IntVariable characterPerPlayer;

    public int CharacterPerPlayer { get => characterPerPlayer.Value; }

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        _onGameStart.Raise();
    }
}
