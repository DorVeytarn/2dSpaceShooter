using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _missionFailedMessage;
    [SerializeField] private LevelMissionTracker _missionTracker;

    private CanvasGroup _winGroup;

    private void Start()
    {
        _winGroup = GetComponent<CanvasGroup>();
        _winGroup.alpha = 0;
        _winGroup.interactable = false;
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _missionTracker.Won += OnWon;

        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _missionTracker.Won -= OnWon;

        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnWon(string message)
    {
        _missionFailedMessage.text = "Миссия: '" + message + "' выполнена!";
        _winGroup.alpha = 1;
        _winGroup.interactable = true;

        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
