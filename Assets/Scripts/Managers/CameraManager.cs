using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    private GameManager _gameManager;
    private CharacterManager _characterManager;


    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private FloatVariable _turnTimer;
    
    public VoidEvent OnEndTurn;

    public GameObject CurrentCamera;
    public GameObject PreviousCamera;

    private int _cameraArrayIndex = 0;

    public List<Camera> Team1Cameras;
    public List<Camera> Team2Cameras;
    public List<Camera> Team3Cameras;
    public List<Camera> Team4Cameras;

    private List<Camera>[] _cameraArray;

    [SerializeField] private int _teamSwitchIndex;
    [SerializeField] private int _characterSwitchIndex;

    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _teamSwitchIndex = 0;
        _characterSwitchIndex = 0;
    }
    public void Init()
    {
        _cameraArray = new List<Camera>[_characterManager.TeamArray.Length];

        _cameraArray[0] = Team1Cameras;

        _cameraArray[1] = Team2Cameras;

        if (_characterManager.TeamArray.Length >= 3)
        {
            _cameraArray[2] = Team3Cameras;
        }
        if (_characterManager.TeamArray.Length >= 4)
        {
            _cameraArray[3] = Team4Cameras;
        }

        foreach (List<GameObject> teamlists in _characterManager.TeamArray)
        {
            foreach (GameObject playerCharacter in _characterManager.TeamArray[_cameraArrayIndex])
            {
                _cameraArray[_cameraArrayIndex].Add(playerCharacter.GetComponent<PlayerCam>().Cam);
            }
            _cameraArrayIndex++;
        }
    }
    public void NextTeam()
    {
        _turnManager.ResetTurnTimer();
        _teamSwitchIndex++;

        if (_teamSwitchIndex == _characterManager.TeamArray.Length)
        {
            _teamSwitchIndex = 0;
        }

        CameraSwitch();

        if (_teamSwitchIndex == 0)
        {
            foreach (GameObject playerCharacter in _characterManager.TeamArray[_gameManager.playerCount -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().IsActive = false;
            }
        }
        else 
        {
            foreach (GameObject playerCharacter in _characterManager.TeamArray[_teamSwitchIndex -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().IsActive = false;
            }
        }
    }
    public void CameraSwitch()
    {
        CurrentCamera = _characterManager.TeamArray[_teamSwitchIndex][_characterSwitchIndex];

        CurrentCamera.gameObject.GetComponent<ActivePlayer>().IsActive = true;
        
        if (CurrentCamera == _characterManager.TeamArray[_teamSwitchIndex][0])
        {
            PreviousCamera = _characterManager.TeamArray[_teamSwitchIndex][_gameManager.CharacterPerPlayer - 1];
        }
        else
        {
            PreviousCamera = _characterManager.TeamArray[_teamSwitchIndex][_characterSwitchIndex - 1];
        }
        
        PreviousCamera.gameObject.GetComponent<ActivePlayer>().IsActive = false;
        PreviousCamera.gameObject.GetComponent<Animator>().SetBool("Ismoving", false);

        _characterSwitchIndex++;

        if (_characterSwitchIndex >= _characterManager.TeamArray[_teamSwitchIndex].Count)
        {
            _characterSwitchIndex = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _turnTimer.Value == _turnTimer.MaxValue)
        {
            CameraSwitch();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextTeam();
        }
    }
}
