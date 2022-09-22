using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CharacterManager characterManager;

    public Camera currentCamera;
    public Camera previousCamera;

    public int currentTeam;

    public List<Camera> team1cameras;




    void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
    }
    public void init()
    {
        foreach (GameObject playerCharacter in characterManager.Team1)
        {
            team1cameras.Add(playerCharacter.GetComponent<Camera>());
        }
    }


    void Update()
    {
        
    }
}
