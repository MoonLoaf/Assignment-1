using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public VoidEvent CameraInit;
    
    GameManager gameManager;
    public GameObject playerCharacter;
    private Vector3 _spawnPoint;

    private float _randomX;
    private float _randomZ;
    [SerializeField] private float _spawnHeight;

    public List<GameObject> Team1;
    public List<GameObject> Team2;
    public List<GameObject> Team3;  
    public List<GameObject> Team4;

    public List<GameObject>[] teamArray;

    public void init()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();


        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
            Team1.Add(playerCharacter);
        }
        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
            Team2.Add(playerCharacter);
        }
        if (gameManager.playerCount == 3)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
                Team3.Add(playerCharacter);
            }
        }
        if (gameManager.playerCount == 4)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
                Team3.Add(playerCharacter);
            }
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Instantiate(playerCharacter, _spawnPoint, Quaternion.identity);
                Team4.Add(playerCharacter);
            }
        }

        if (Team1.Count != 0)
        {
            Team1 = teamArray[0];
        }
        if (Team2.Count != 0)
        {
            Team2 = teamArray[1];
        }
        if (Team3.Count != 0)
        {
            Team3 = teamArray[2];
        }
        if (Team4.Count != 0)
        {
            Team4 = teamArray[3];
        }

        CameraInit.Raise();
    }
    private void GenerateSpawnPoint()
    {
        _randomX = Random.Range(-50, 20);
        _randomZ = Random.Range(0, 65);

        _spawnPoint = new Vector3(_randomX, _spawnHeight, _randomZ);
    }
}
