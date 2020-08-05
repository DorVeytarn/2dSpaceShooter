using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _levelButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _settingslButton;

    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private List<LevelView> _levelViews = new List<LevelView>();

    private Scene _sceneForDownload;
    private LevelView _currentLevelView;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _levelButton.onClick.AddListener(OnLevelButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _settingslButton.onClick.AddListener(OnSettingsButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _levelButton.onClick.RemoveListener(OnLevelButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _settingslButton.onClick.RemoveListener(OnSettingsButtonClick);
    }

    private void Start()
    {
        _levelPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    private void OnPlayButtonClick()
    {
        _currentLevelView = _levelViews.FirstOrDefault(levelView => levelView.CurrentOpenStatus == true);
        print(_currentLevelView.name);
        SceneManager.LoadScene(_currentLevelView.LevelScene.handle);
    }

    private void OnLevelButtonClick()
    {
        _levelPanel.SetActive(true);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnSettingsButtonClick()
    {
        _settingsPanel.SetActive(true);
    }


}
