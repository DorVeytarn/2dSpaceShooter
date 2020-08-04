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
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _pauseButton;

    [SerializeField] private Text _missionFailedMessage;
    [SerializeField] private LevelMissionTracker _missionTracker;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private CanvasGroup _winGroup;


    private void OnEnable()
    {
        _missionTracker.Won += OnWon;

        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _missionTracker.Won -= OnWon;

        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _nextButton.onClick.RemoveListener(OnNextButtonClick);
    }

    private void Start()
    {
        gameObject.SetActive(true);
        ChangeActiveOtherPanel(true);

        _winGroup = GetComponent<CanvasGroup>();
        _winGroup.alpha = 0;
        _winGroup.interactable = false;
        Time.timeScale = 1;
    }

    private void OnWon(string message)
    {
        ChangeActiveOtherPanel(false);

        _missionFailedMessage.text = "Миссия: '" + message + "' выполнена!";
        _winGroup.alpha = 1;
        _winGroup.interactable = true;

        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        ChangeActiveOtherPanel(true);

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnNextButtonClick()
    {
        Time.timeScale = 1;
        int nextSceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        
        nextSceneNumber = (nextSceneNumber < SceneManager.sceneCountInBuildSettings) ? nextSceneNumber : SceneManager.GetActiveScene().handle;

        ChangeActiveOtherPanel(true);

        SceneManager.LoadScene(nextSceneNumber);
    }

    private void ChangeActiveOtherPanel(bool active)
    {
        _pauseButton.gameObject.SetActive(active);
        _gameOverScreen.gameObject.SetActive(active);
    }

}
