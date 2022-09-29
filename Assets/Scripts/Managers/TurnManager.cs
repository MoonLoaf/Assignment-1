using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public float CurrentTurnTimer;
    private float _fullTurnTimer = 100;

    [SerializeField] private Image _turnTimerBar;
    void Start()
    {
        _turnTimerBar.fillAmount = 100;
    }
    void Update()
    {
        _turnTimerBar.fillAmount =- 1 * Time.deltaTime;
    }

    public void ResetTurnTimer()
    {
        CurrentTurnTimer = _fullTurnTimer;
    }
}
