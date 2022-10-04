using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool InputEnabled;
    
    [SerializeField]private VoidEvent _onGameStart;

    [Header("Main Menu Settings")]

    [SerializeField] private IntVariable _playerCount;

    [SerializeField] private IntVariable _characterPerPlayer;

    public int CharacterPerPlayer { get => _characterPerPlayer.Value; }
    public int playerCount { get => _playerCount.Value; }

    private void Start()
    {
        StartGame();
        InputEnabled = false;

        StartCoroutine(LoadingScreen());

    }
    private void StartGame()
    {
        _onGameStart.Raise();
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(2.5f);

        InputEnabled = true;

        yield return new WaitForEndOfFrame();
    }
}
