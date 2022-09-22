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
        characterManager = FindObjectOfType<CameraManager>().GetComponent<CharacterManager>();
    }
    public void init()
    {
        foreach (List<GameObject> teamLists in characterManager.teamArray)
        {
            teamLists.ForEach(t => gameObject.GetComponent<Camera>());
            
        }
    }


    void Update()
    {
        
    }
}
