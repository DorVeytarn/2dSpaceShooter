using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _parentPanel;

    private void Start()
    {
        _parentPanel.SetActive(false);
    }
    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }

    private void OnBackButtonClick()
    {
        _parentPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);

        _backButton.onClick.AddListener(OnBackButtonClick);
    }
}
