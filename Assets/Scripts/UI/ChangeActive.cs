using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour
{
    [SerializeField] private GameObject _targetGameObjcet;

    public void SetActiveFalse()
    {
        _targetGameObjcet.SetActive(false);
    }

    public void SetActiveTrue()
    {
        Time.timeScale = 0;
        _targetGameObjcet.SetActive(true);
    }
}
