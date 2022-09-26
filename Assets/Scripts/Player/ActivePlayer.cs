using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    PlayerMovement movementScript;
    PlayerCam camScript;
    PlayerAnimation animScript;

    public bool isActive;

    private Camera cam;

    void Start()
    {
        isActive = false;

        movementScript = GetComponent<PlayerMovement>();
        camScript = GetComponent<PlayerCam>();
        animScript = GetComponent<PlayerAnimation>();

        cam = this.gameObject.GetComponentInChildren<Camera>();

    }

    void Update()
    {
        if (!isActive)
        {
            this.movementScript.enabled = false;
            this.camScript.enabled = false;
            this.animScript.enabled = false;
            cam.enabled = false;
        }
        if (isActive)
        {
            this.movementScript.enabled = true;
            this.camScript.enabled = true;
            this.animScript.enabled = true;
            cam.enabled = true;
        }
    }
}
