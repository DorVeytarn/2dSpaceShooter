using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideJoystick : MonoBehaviour
{
    [SerializeField] private LevelMissionTracker _missionTracker;
    private Joystick _joystick;

    private void Start()
    {
        _joystick = GetComponent<Joystick>();
    }

    private void OnEnable()
    {
        _missionTracker.Won += Hide;
        _missionTracker.MissionFailed += Hide;
    }

    private void OnDisable()
    {
        _missionTracker.Won -= Hide;
        _missionTracker.MissionFailed -= Hide;
    }

    private void Hide(string message)
    {
        _joystick.gameObject.SetActive(false);
    }
}
