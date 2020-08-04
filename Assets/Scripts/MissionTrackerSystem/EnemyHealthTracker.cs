using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    private Enemy _enemy;
    private LevelMissionTracker _missionTracker;
    private Text _score;
    private int _diedEnemyCount;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _missionTracker = GameObject.FindWithTag("LevelMissionTracker").GetComponent<LevelMissionTracker>();

        _enemy.KilledByPlayer += OnKilledByPlayer;   
    }

    private void OnDisable()
    {
        _enemy.KilledByPlayer -= OnKilledByPlayer;
    }

    private void OnKilledByPlayer()
    {
        if (_missionTracker.ActiveDeathRequiredAmount)
        {
            _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

            _missionTracker.OnEnemyKilled();
            _score.text = _missionTracker.CurrentEnemyDeath.ToString();
        }
    }



}
