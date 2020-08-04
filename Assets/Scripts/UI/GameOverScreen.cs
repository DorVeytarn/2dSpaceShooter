using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Text _missionFailedMessage;

    [SerializeField] private Player _player;
    [SerializeField] private LevelMissionTracker _missionTracker;
    [SerializeField] private WinScreen _winScreen;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _missionTracker.MissionFailed += OnMissionFailed;

        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _missionTracker.MissionFailed -= OnMissionFailed;

        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Start()
    {
        gameObject.SetActive(true);
        ChangeActiveOtherPanel(true);

        _gameOverGroup = GetComponent<CanvasGroup>();

        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;


    }

    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;

        ChangeActiveOtherPanel(false);    
    }

    private void OnMissionFailed(string message)
    {
        ChangeActiveOtherPanel(false);

        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;

        _missionFailedMessage.text = "Миссия: '" + message + "' провалена!";
    }

    private void OnRestartButtonClick()
    {
        _pauseButton.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeActiveOtherPanel(bool active)
    {
        _pauseButton.gameObject.SetActive(active);
        _winScreen.gameObject.SetActive(active);
    }
}
