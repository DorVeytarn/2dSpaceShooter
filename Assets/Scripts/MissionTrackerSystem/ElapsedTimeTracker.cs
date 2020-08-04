using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapsedTimeTracker : MonoBehaviour
{
    [SerializeField] private LevelMissionTracker _missionTracker;
    [SerializeField] private Text _timer;
    [SerializeField] private Player _player;

    private float _currentTime;

    private void Start()
    {
        _currentTime = _missionTracker.TimeToHoldOut;
        _timer.text = Mathf.RoundToInt(_currentTime).ToString();
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void Update()
    {
        if (ChekHoldOutTimer())
            HoldOutTimeTracking();
        else
        {
            UntouchableTimerTracking();
        }
    }

    private bool ChekHoldOutTimer()
    {
        if (_missionTracker.TimeToHoldOut == 0)
            return false;
        else return true;
    }

    private void HoldOutTimeTracking()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
        else if (_currentTime <= 0)
        {
            _currentTime = 0;
            _missionTracker.OnTimeIsOver(_currentTime);
        }
        _timer.text = Mathf.RoundToInt(_currentTime).ToString();
    }

    private void UntouchableTimerTracking()
    {
        _currentTime += Time.deltaTime;
        _timer.text = Mathf.RoundToInt(_currentTime).ToString();

        if (_currentTime >= _missionTracker.UntouchableTimeToHoldOut)
        {
            _missionTracker.OnPlayerReceivedDamage(false);
        }
    }

    private void OnDied()
    {
        _missionTracker.OnTimeIsOver(_currentTime);
    }



   
}
