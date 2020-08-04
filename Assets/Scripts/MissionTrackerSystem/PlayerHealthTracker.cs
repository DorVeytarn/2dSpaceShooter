using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealthTracker : MonoBehaviour
{
    private LevelMissionTracker _missionTracker;
    private Player _player;

    private void Start()
    {
        _missionTracker = GameObject.FindGameObjectWithTag("LevelMissionTracker").GetComponent<LevelMissionTracker>();
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int healthValue)
    {
        if (healthValue < _player.MaxHealth)
        {
            _missionTracker.OnPlayerReceivedDamage(true);
        }
    }

}
