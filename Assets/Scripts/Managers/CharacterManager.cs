using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public VoidEvent CameraInit;
    public VoidEvent CharacterUIinit;
    public VoidEvent TeamDeathCheckInit;
    
    private GameManager _gameManager;
    private Vector3 _spawnPoint;

    //Playable Characters

    private List<GameObject> _characterPrefabList = new List<GameObject>();
    public GameObject CharacterPrefab1;
    public GameObject CharacterPrefab2;
    public GameObject CharacterPrefab3;
    public GameObject CharacterPrefab4;
    public GameObject CharacterPrefab5;
    public GameObject CharacterPrefab6;


    private float _randomX;
    private float _randomZ;
    [SerializeField] private float _spawnHeight;

    public List<GameObject> Team1;
    public List<GameObject> Team2;
    public List<GameObject> Team3;
    public List<GameObject> Team4;

    public List<GameObject>[] TeamArray;
    public int TeamArrayIndex;

    public void Init()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        _characterPrefabList.Add(CharacterPrefab1);
        _characterPrefabList.Add(CharacterPrefab2);
        _characterPrefabList.Add(CharacterPrefab3);
        _characterPrefabList.Add(CharacterPrefab4);
        _characterPrefabList.Add(CharacterPrefab5);
        _characterPrefabList.Add(CharacterPrefab6);

        TeamArray = new List<GameObject>[_gameManager.playerCount];


        for (int i = 0; i < _gameManager.CharacterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            int prefabIndex = Random.Range(0, 5);
            Team1.Add(Instantiate(_characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
        }
        for (int i = 0; i < _gameManager.CharacterPerPlayer; i++)
        {
            GenerateSpawnPoint();
            int prefabIndex = Random.Range(0, 5);
            Team2.Add(Instantiate(_characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));

        }
        if (_gameManager.playerCount == 3)
        {
            for (int i = 0; i < _gameManager.CharacterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 5);
                Team3.Add(Instantiate(_characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
            }
        }
        if (_gameManager.playerCount == 4)
        {
            for (int i = 0; i < _gameManager.CharacterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 5);
                Team3.Add(Instantiate(_characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
            }
            for (int i = 0; i < _gameManager.CharacterPerPlayer; i++)
            {
                GenerateSpawnPoint();
                int prefabIndex = Random.Range(0, 5);
                Team4.Add(Instantiate(_characterPrefabList[prefabIndex], _spawnPoint, Quaternion.identity));
            }
        }

        if (Team1.Count != 0)
        {
            TeamArray[0] = Team1;
        }
        if (Team2.Count != 0)
        {
            TeamArray[1] = Team2;
        }
        if (Team3.Count != 0)
        {
            TeamArray[2] = Team3;
        }
        if (Team4.Count != 0)
        {
            TeamArray[3] = Team4; 
        }

        CameraInit.Raise();
        CharacterUIinit.Raise();
        TeamDeathCheckInit.Raise();
    }
    private void GenerateSpawnPoint()
    {
        _randomX = Random.Range(-50, 20);
        _randomZ = Random.Range(0, 65);

        _spawnPoint = new Vector3(_randomX, _spawnHeight, _randomZ);
    }
}
