using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    GameManager _gameManager;
    CharacterManager _characterManager;


    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private FloatVariable turnTimer;
    
    public VoidEvent onEndTurn;

    public GameObject currentCamera;
    public GameObject previousCamera;

    private int _cameraArrayIndex = 0;

    public List<Camera> team1Cameras;
    public List<Camera> team2Cameras;
    public List<Camera> team3Cameras;
    public List<Camera> team4Cameras;

    private List<Camera>[] _cameraArray;

    [SerializeField] private int teamSwitchIndex;
    [SerializeField] private int characterSwitchIndex;

    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        teamSwitchIndex = 0;
        characterSwitchIndex = 0;
    }
    public void Init()
    {
        _cameraArray = new List<Camera>[_characterManager.teamArray.Length];

        _cameraArray[0] = team1Cameras;

        _cameraArray[1] = team2Cameras;

        if (_characterManager.teamArray.Length >= 3)
        {
            _cameraArray[2] = team3Cameras;
        }
        if (_characterManager.teamArray.Length >= 4)
        {
            _cameraArray[3] = team4Cameras;
        }

        foreach (List<GameObject> teamlists in _characterManager.teamArray)
        {
            foreach (GameObject playerCharacter in _characterManager.teamArray[_cameraArrayIndex])
            {
                _cameraArray[_cameraArrayIndex].Add(playerCharacter.GetComponent<PlayerCam>().cam);
            }
            _cameraArrayIndex++;
        }
    }
    public void NextTeam()
    {
        _turnManager.ResetTurnTimer();
        teamSwitchIndex++;

        if (teamSwitchIndex == _characterManager.teamArray.Length)
        {
            teamSwitchIndex = 0;
        }

        CameraSwitch();

        if (teamSwitchIndex == 0)
        {
            foreach (GameObject playerCharacter in _characterManager.teamArray[_gameManager.playerCount -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().isActive = false;
            }
        }
        else 
        {
            foreach (GameObject playerCharacter in _characterManager.teamArray[teamSwitchIndex -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().isActive = false;
            }
        }
    }
    public void CameraSwitch()
    {
        currentCamera = _characterManager.teamArray[teamSwitchIndex][characterSwitchIndex];

        currentCamera.gameObject.GetComponent<ActivePlayer>().isActive = true;
        
        if (currentCamera == _characterManager.teamArray[teamSwitchIndex][0])
        {
            previousCamera = _characterManager.teamArray[teamSwitchIndex][_gameManager.CharacterPerPlayer - 1];
        }
        else
        {
            previousCamera = _characterManager.teamArray[teamSwitchIndex][characterSwitchIndex - 1];
        }
        
        previousCamera.gameObject.GetComponent<ActivePlayer>().isActive = false;
        previousCamera.gameObject.GetComponent<Animator>().SetBool("Ismoving", false);

        characterSwitchIndex++;

        if (characterSwitchIndex >= _characterManager.teamArray[teamSwitchIndex].Count)
        {
            characterSwitchIndex = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && turnTimer.Value == turnTimer.MaxValue)
        {
            CameraSwitch();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextTeam();
        }
    }
}
