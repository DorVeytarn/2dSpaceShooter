using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelMissionTracker : MonoBehaviour
{
    [SerializeField] private string _missionName;

    [Multiline(4)]
    [SerializeField] private string _missionDiscription;

    [Header("Убить Х врагов для победы")]
    [SerializeField] private int _deathRequiredAmount;
    [SerializeField] private bool _activeDeathRequiredAmount;

    [Header("Продержаться Х секунд для победы")]
    [SerializeField] private int _timeToHoldOut;
    [SerializeField] private bool _activeTimeToHoldOut;


    [Header("Не получить урона и продержаться Х секунд для победы")]
    [SerializeField] private bool _untouchable;
    [SerializeField] private float _untouchableTimeToHoldOut;
    [SerializeField] private bool _activeUntouchable;


    [Header("Игровой таймер")]
    [SerializeField] private float _timer;

    private Player _player;
    private int _currentEnemyDeath;

    public event UnityAction<string> MissionFailed;
    public event UnityAction<string> Won;
    public int TimeToHoldOut => _timeToHoldOut;



    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void OnEnemyKilled()
    {
        if (_activeDeathRequiredAmount)
        {
            _currentEnemyDeath++;
            if (_currentEnemyDeath >= _deathRequiredAmount)
                Won?.Invoke(_missionName);
        }
    }

    public void OnTimeIsOver(float timeValue)
    {
        if (_activeTimeToHoldOut)
        {
            if (timeValue == 0)
                Won?.Invoke(_missionName);
            else
                MissionFailed?.Invoke(_missionName);
        }
    }

    public void OnPlayerReceivedDamage(bool receivedDamage)
    {
        if (_activeUntouchable)
        {
            if (receivedDamage == _untouchable && _timer >= _untouchableTimeToHoldOut)
                Won?.Invoke(_missionName);
            else MissionFailed?.Invoke(_missionName);
        }
    }
}
