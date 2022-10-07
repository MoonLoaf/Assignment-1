using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Pistol : MonoBehaviour
{
    
    [SerializeField] private Camera _cam;
    private RaycastHit _rayHit;
    [SerializeField] private ParticleSystem _gunShot;

    [SerializeField] private FloatVariable _turnTimer;
    
    private int _maxAmmo;
    public int CurrentAmmo;

    private static float _damage;
    public static float Damage { get => _damage; }
    
    private float _range;
    public bool Reloading;
    private float _reloadTime;
    private float _timeBetweenShots;
    
    

    private bool _shotReady;
    private bool _isAiming;
    
    void Awake()
    {
        _cam = GetComponentInChildren<Camera>();
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
        if (_isAiming && Input.GetKeyDown(KeyCode.Mouse0) && CurrentAmmo >= 1 && !Reloading && _shotReady && _turnTimer.Value >= 0.1f && GameManager.InputEnabled)
        {
            Shoot();
            _gunShot.Play();
            _shotReady = false;
            Invoke(nameof(ResetShot), _timeBetweenShots);
        }
        if (Input.GetKeyDown(KeyCode.R) && _turnTimer.Value >= 0.2f)
        {
            Reload();
            Invoke(nameof(ReloadFinished), _reloadTime);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            _isAiming = true;
        }
        else
        {
            _isAiming = false;
        }
    }
    void Shoot()
    {
        var camPosition = _cam.transform;
        Physics.Raycast(camPosition.position, camPosition.forward, out _rayHit, _range);

        CurrentAmmo--;
        _turnTimer.ApplyChange(-0.1f);

        if (_rayHit.collider != null)
        {
            if (_rayHit.collider.CompareTag("Player"))
            {
                float calculatedDamage = Damage / _rayHit.distance;
                if (calculatedDamage >= 20)
                {
                    calculatedDamage = 20;
                }
                _rayHit.collider.GetComponent<PlayerHP>().TakeDamage(calculatedDamage);
            }
        }
    }
    private void Reload()
    {
        Reloading = true;
        CurrentAmmo = _maxAmmo;
        _turnTimer.ApplyChange(-0.2f);
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
