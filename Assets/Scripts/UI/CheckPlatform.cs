using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;

    private void Start()
    {
        _joystick.SetActive(false);
        CheckCurrentPlatform();
    }

    private void CheckCurrentPlatform()
    {
        if (Application.isMobilePlatform)
            _joystick.SetActive(true);
    }
}
