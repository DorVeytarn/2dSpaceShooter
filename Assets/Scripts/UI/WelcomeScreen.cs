using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    [SerializeField] LevelMissionTracker _missionTracker;
    [SerializeField] private Button _playButton;
    [SerializeField] private Text _text;

    private string _message;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Start()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        _message = _missionTracker.MissionDiscription;
        _text.text = _message;
    }

    private void OnPlayButtonClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
