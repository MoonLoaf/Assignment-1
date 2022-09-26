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
    public int teamArrayIndex;

    public void init()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        teamArray = new List<GameObject>[gameManager.playerCount];

        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            Team1.Add(Instantiate(playerCharacter, _spawnPoint, Quaternion.identity));
        }
        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            Team2.Add(Instantiate(playerCharacter, _spawnPoint, Quaternion.identity));
            
        }
        if (gameManager.playerCount == 3)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Team3.Add(Instantiate(playerCharacter, _spawnPoint, Quaternion.identity));
            }
        }
        if (gameManager.playerCount == 4)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Team3.Add(Instantiate(playerCharacter, _spawnPoint, Quaternion.identity));
            }
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                Team4.Add(Instantiate(playerCharacter, _spawnPoint, Quaternion.identity));
            }
        }

        if (Team1.Count != 0)
        {
            teamArray[0] = Team1;
        }
        if (Team2.Count != 0)
        {
            teamArray[1] = Team2;
        }
        if (Team3.Count != 0)
        {
            teamArray[2] = Team3;
        }
        if (Team4.Count != 0)
        {
            teamArray[3] = Team4; 
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
