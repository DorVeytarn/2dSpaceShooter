using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeathEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSound;

    public void OnDied()
    {
        AudioSource.PlayClipAtPoint(_shootSound, transform.position, 1f);
    }
}
