using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    private CameraManager _cameraManager;

    private PlayerMovement _movementScript;
    private PlayerCam _camScript;
    private PlayerAnimation _animScript;
    private MeleeAttack _meleeAttack;

    private Pistol _pistol;

    public bool IsActive = true;

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
        if (!IsActive)
        {
            this._movementScript.enabled = false;
            this._camScript.enabled = false;
            this._animScript.enabled = false;

            this._pistol.enabled = false;
            this._meleeAttack.enabled = false;
            
            _cam.enabled = false;
        }
        if (IsActive && !_playerHp.IsDead)
        {
            this._movementScript.enabled = true;
            this._camScript.enabled = true;
            this._animScript.enabled = true;

            this._pistol.enabled = true;
            this._meleeAttack.enabled = true;
            
            _cam.enabled = true;
        }
        else if(IsActive && _playerHp.IsDead)
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
        IsActive = false;
        _cameraManager.CameraSwitch();
    }
}
