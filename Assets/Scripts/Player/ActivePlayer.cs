using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    CameraManager _cameraManager;

    PlayerMovement _movementScript;
    PlayerCam _camScript;
    PlayerAnimation _animScript;
    private MeleeAttack _meleeAttack;

    Pistol _pistol;

    public bool isActive = true;

    private Camera _cam;
    private PlayerHP _playerHp;

    void Start()
    {
        _playerHp = gameObject.GetComponent<PlayerHP>();
        _cameraManager = FindObjectOfType<CameraManager>().GetComponent<CameraManager>();

        Invoke("SetInactive", 2.5f);

        _movementScript = GetComponent<PlayerMovement>();
        _camScript = GetComponent<PlayerCam>();
        _animScript = GetComponent<PlayerAnimation>();

        _pistol = GetComponent<Pistol>();
        _meleeAttack = GetComponent<MeleeAttack>();
        
        _cam = this.gameObject.GetComponentInChildren<Camera>();

    }

    void Update()
    {
        if (!isActive)
        {
            this._movementScript.enabled = false;
            this._camScript.enabled = false;
            this._animScript.enabled = false;

            this._pistol.enabled = false;
            this._meleeAttack.enabled = false;
            
            _cam.enabled = false;
        }
        if (isActive && !_playerHp.IsDead)
        {
            this._movementScript.enabled = true;
            this._camScript.enabled = true;
            this._animScript.enabled = true;

            this._pistol.enabled = true;
            this._meleeAttack.enabled = true;
            
            _cam.enabled = true;
        }
        else if(isActive && _playerHp.IsDead)
        {
            this._movementScript.enabled = false;
            this._camScript.enabled = false;
            this._animScript.enabled = false;

            this._pistol.enabled = false;
            this._meleeAttack.enabled = false;
            
            _cam.enabled = true;
        }
    }
    public void SetInactive()
    {
        isActive = false;
        _cameraManager.CameraSwitch();
    }
}
