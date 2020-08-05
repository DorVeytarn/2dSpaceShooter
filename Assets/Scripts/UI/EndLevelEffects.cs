using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EndLevelEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _failSound;
    [SerializeField] private AudioClip _winSound;


    public void OnWin()
    {
        AudioSource.PlayClipAtPoint(_winSound, transform.position, 0.5f);
    }

    public void OnFail()
    {
        AudioSource.PlayClipAtPoint(_failSound, transform.position, 2f);
    }
}
