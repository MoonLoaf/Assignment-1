using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CharacterManager characterManager;
    public VoidEvent onEndTurn;

    public Camera currentCamera;
    public Camera previousCamera;

    public int currentTeam;
    private int CameraArrayIndex = 0;

    public List<Camera> team1Cameras;
    public List<Camera> team2Cameras;
    public List<Camera> team3Cameras;
    public List<Camera> team4Cameras;

    public List<Camera>[] CameraArray;

    void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
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

        Debug.Log(characterManager.teamArray.Length);
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

    }
    public void CameraSwitch()
    {
        Debug.Log(team1Cameras[0].enabled);
        team1Cameras[0].enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraSwitch();
            Debug.Log("CameraSwitch");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //CurrentCamera --;
        }
;
    }
}
