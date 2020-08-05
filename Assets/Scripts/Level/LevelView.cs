using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelView : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Scene _levelScene;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _lockImage;
    [SerializeField] private Text _label;
    [SerializeField] private Text _status;

    private bool _currentOpenStatus = false;

    public bool CurrentOpenStatus => _currentOpenStatus;
    public Scene LevelScene => _levelScene;

    private void Awake()
    {
        SetLevelView();
    }

    private void SetLevelView()
    {
        _icon = _levelData.Icon;
        _lockImage.gameObject.SetActive(false);
        _label.text = _levelData.Label;

        if (_levelData.Open && _levelData.Passed)
            _status.text = "Status: Passed";
        else if (_levelData.Open)
        {
            _status.text = "Status: Open";
            _currentOpenStatus = true;
        }
        else if (_levelData.Passed)
            _status.text = "Status: Passed";
        else if (_levelData.Closed)
        {
            _status.text = "Status: Closed";
            _currentOpenStatus = false;
            _lockImage.gameObject.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!_lockImage.gameObject.activeSelf)
            SceneManager.LoadScene(_levelScene.handle);
    }
}
