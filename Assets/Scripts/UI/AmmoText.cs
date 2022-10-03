using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoText : MonoBehaviour
{
    private Pistol _pistol;
    private TMP_Text _ammoText;
    
    void Start()
    {
        _ammoText = GetComponent<TMP_Text>();
        _pistol = GetComponentInParent<Pistol>();
    }
    void Update()
    {
        if (_pistol.Reloading == true)
        {
            _ammoText.text = "Reloading...";
        }
        else
        {
            _ammoText.text ="Ammo: " + _pistol.CurrentAmmo.ToString() + "/6";
        }
    }
    
}
