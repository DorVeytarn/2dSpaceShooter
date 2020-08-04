using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthTracker : MonoBehaviour
{
    private Enemy _enemy;
    private LevelMissionTracker _missionTracker;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.KilledByPlayer += OnKilledByPlayer;   
    }

    private void OnDisable()
    {
        _enemy.KilledByPlayer -= OnKilledByPlayer;
    }

    private void OnKilledByPlayer()
    {
        _missionTracker = GameObject.FindWithTag("LevelMissionTracker").GetComponent<LevelMissionTracker>();
        _missionTracker.OnEnemyKilled();
    }



}
