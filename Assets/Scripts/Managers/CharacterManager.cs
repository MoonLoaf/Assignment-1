using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public VoidEvent CameraInit;
    public VoidEvent CharacterUIinit;
    
    GameManager gameManager;
    private Vector3 _spawnPoint;

    //Playable Characters

    List<GameObject> characterPrefabList = new List<GameObject>();
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;
    public GameObject characterPrefab3;
    public GameObject characterPrefab4;
    public GameObject characterPrefab5;
    public GameObject characterPrefab6;
    public GameObject characterPrefab7;


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

        characterPrefabList.Add(characterPrefab1);
        characterPrefabList.Add(characterPrefab2);
        characterPrefabList.Add(characterPrefab3);
        characterPrefabList.Add(characterPrefab4);
        characterPrefabList.Add(characterPrefab5);
        characterPrefabList.Add(characterPrefab6);
        characterPrefabList.Add(characterPrefab7);

        teamArray = new List<GameObject>[gameManager.playerCount];


        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            int prefabIndex = Random.Range(0, 6);
            Team1.Add(Instantiate(characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
        }
        for (int i = 0; i < gameManager.characterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            int prefabIndex = Random.Range(0, 6);
            Team2.Add(Instantiate(characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));

        }
        if (gameManager.playerCount == 3)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 6);
                Team3.Add(Instantiate(characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
            }
        }
        if (gameManager.playerCount == 4)
        {
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 6);
                Team3.Add(Instantiate(characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
            }
            for (int i = 0; i < gameManager.characterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 6);
                Team4.Add(Instantiate(characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
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
        CharacterUIinit.Raise();
    }
    private void GenerateSpawnPoint()
    {
        _randomX = Random.Range(-50, 20);
        _randomZ = Random.Range(0, 65);

        _spawnPoint = new Vector3(_randomX, _spawnHeight, _randomZ);
    }
}
