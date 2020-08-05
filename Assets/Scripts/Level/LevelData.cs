using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField] private string _lable;
    [Multiline(3)]
    [SerializeField] private string _description;
    [SerializeField] private Image _icon;

    public bool Closed;
    public bool Open;
    public bool Passed;

    public string Label => _lable;
    public string Description => _description;
    public Image Icon => _icon;

    
}
