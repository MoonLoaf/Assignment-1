using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject playerCharacter;
    private Vector3 _spawnPoint;

    private float _randomX;
    private float _randomZ;
    [SerializeField] private float _spawnHeight;

    public void init()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        for (int i  = 0; i < gameManager.playerCount * gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
            Debug.Log(_spawnPoint);
        }
    }
    private void GenerateSpawnPoint()
    {
        _randomX = Random.Range(-50, 20);
        _randomZ = Random.Range(0, 65);

        _spawnPoint = new Vector3(_randomX, _spawnHeight, _randomZ);
    }
}
