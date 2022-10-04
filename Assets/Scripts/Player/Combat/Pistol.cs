using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pistol : MonoBehaviour
{
    [FormerlySerializedAs("_cam")] [SerializeField] private Camera cam;
    private RaycastHit _rayHit;

    [SerializeField] private FloatVariable TurnTimer;
    
    private int _maxAmmo;
    public int CurrentAmmo;
    
    

    private static float _damage;
    
    public static float Damage { get => _damage; }
    
    private float _range;
    public bool Reloading;
    private float _reloadTime;
    private float _timeBetweenShots;

    private bool _shotReady;
    
    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        //FindAmmoText();
    }
    void Start()
    {
        _maxAmmo = 6;
        CurrentAmmo = _maxAmmo;
        _range = 1000;
        _reloadTime = 2;
        _damage = 100;
        
        _timeBetweenShots = 0.3f;

        _shotReady = true;
    }
    void Update()
    {
        WeaponInputs();
    }
    // ReSharper disable Unity.PerformanceAnalysis
    void WeaponInputs()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CurrentAmmo >= 1 && !Reloading && _shotReady && TurnTimer.Value >= 0.1f && GameManager.InputEnabled)
        {
            Shoot();
            _shotReady = false;
            Invoke(nameof(ResetShot), _timeBetweenShots);
        }
        if (Input.GetKeyDown(KeyCode.R) && TurnTimer.Value >= 0.2f)
        {
            Reload();
            Invoke(nameof(ReloadFinished), _reloadTime);
        }
    }

    void Shoot()
    {
        var camPosition = cam.transform;
        Physics.Raycast(camPosition.position, camPosition.forward, out _rayHit, _range);

        CurrentAmmo--;
        TurnTimer.ApplyChange(-0.1f);

        if (_rayHit.collider != null)
        {
            if (_rayHit.collider.CompareTag("Player"))
            {
                _rayHit.collider.GetComponent<PlayerHP>().TakeDamage(Damage / _rayHit.distance);
            }
        }
        
        
        
    }
    private void Reload()
    {
        Reloading = true;
        CurrentAmmo = _maxAmmo;
        TurnTimer.ApplyChange(-0.2f);
    }
    private void ReloadFinished()
    {
        Reloading = false;
    }
    private void ResetShot()
    {
        _shotReady = true;
    }
}
