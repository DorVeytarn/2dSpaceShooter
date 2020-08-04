using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelMissionTracker : MonoBehaviour
{
    [Multiline(4)] private string _missionDiscription;
    [SerializeField] private string _missionName;
    [SerializeField] private int _deathRequiredAmount;

    [SerializeField] private Player _player;
    [SerializeField] private UnityEvent _won;

    private int _currentEnemyDeath;


    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void OnEnemyKilled()
    {
        _deathRequiredAmount++;
        print(_deathRequiredAmount);
    }



}
