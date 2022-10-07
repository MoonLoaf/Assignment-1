using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]private FloatVariable _currentTurnTimer;

    private Image _turnTimerBar;
    
    void Start()
    {
        _turnTimerBar = GetComponent<Image>();
        _currentTurnTimer.Value = _currentTurnTimer.MaxValue;
    }
    void Update()
    {
        _turnTimerBar.fillAmount = _currentTurnTimer.Value;
    }

    public void ResetTurnTimer()
    {
        _currentTurnTimer.Value = _currentTurnTimer.MaxValue;
    }
}
