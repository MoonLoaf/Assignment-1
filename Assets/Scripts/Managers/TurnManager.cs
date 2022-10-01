using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]private FloatVariable CurrentTurnTimer;

    private Image _turnTimerBar;
    
    void Start()
    {
        _turnTimerBar = GetComponent<Image>();
        CurrentTurnTimer.Value = CurrentTurnTimer.MaxValue;
    }
    void Update()
    {
        _turnTimerBar.fillAmount = CurrentTurnTimer.Value;
    }

    public void ResetTurnTimer()
    {
        CurrentTurnTimer.Value = CurrentTurnTimer.MaxValue;
    }
}
