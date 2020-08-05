using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButtons : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _parentPanel;

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
    }
}
