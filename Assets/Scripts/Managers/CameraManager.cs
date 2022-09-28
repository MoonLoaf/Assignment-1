using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameManager gameManager;
    CharacterManager characterManager;
   

    public VoidEvent onEndTurn;

    public GameObject currentCamera;
    public GameObject previousCamera;

    private int CameraArrayIndex = 0;

    public List<Camera> team1Cameras;
    public List<Camera> team2Cameras;
    public List<Camera> team3Cameras;
    public List<Camera> team4Cameras;

    public List<Camera>[] CameraArray;

    [SerializeField] private int teamSwitchIndex;
    [SerializeField] private int characterSwitchIndex;

    void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        teamSwitchIndex = 0;
        characterSwitchIndex = 0;
    }
    public void init()
    {
        CameraArray = new List<Camera>[characterManager.teamArray.Length];

        CameraArray[0] = team1Cameras;

        CameraArray[1] = team2Cameras;

        if (characterManager.teamArray.Length >= 3)
        {
            CameraArray[2] = team3Cameras;
        }
        if (characterManager.teamArray.Length >= 4)
        {
            CameraArray[3] = team4Cameras;
        }

        foreach (List<GameObject> teamlists in characterManager.teamArray)
        {
            foreach (GameObject playerCharacter in characterManager.teamArray[CameraArrayIndex])
            {
                CameraArray[CameraArrayIndex].Add(playerCharacter.GetComponent<PlayerCam>().cam);
            }
            CameraArrayIndex++;
        }
    }
    public void NextTeam()
    {
        teamSwitchIndex++;

        if (teamSwitchIndex == characterManager.teamArray.Length)
        {
            teamSwitchIndex = 0;
        }

        CameraSwitch();

        if (teamSwitchIndex == 0)
        {
            foreach (GameObject playerCharacter in characterManager.teamArray[gameManager.playerCount -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().isActive = false;
            }
        }
        else 
        {
            foreach (GameObject playerCharacter in characterManager.teamArray[teamSwitchIndex -1])
            {
                playerCharacter.GetComponent<ActivePlayer>().isActive = false;
            }
        }
    }
    public void CameraSwitch()
    {
        currentCamera = characterManager.teamArray[teamSwitchIndex][characterSwitchIndex];

        currentCamera.gameObject.GetComponent<ActivePlayer>().isActive = true;
        
        if (currentCamera == characterManager.teamArray[teamSwitchIndex][0])
        {
            previousCamera = characterManager.teamArray[teamSwitchIndex][gameManager.characterPerPlayer - 1];
        }
        else
        {
            previousCamera = characterManager.teamArray[teamSwitchIndex][characterSwitchIndex - 1];
        }
        
        previousCamera.gameObject.GetComponent<ActivePlayer>().isActive = false;
        previousCamera.gameObject.GetComponent<Animator>().SetBool("Ismoving", false);

        characterSwitchIndex++;

        if (characterSwitchIndex >= characterManager.teamArray[teamSwitchIndex].Count)
        {
            characterSwitchIndex = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraSwitch();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextTeam();
        }
;
    }
}
