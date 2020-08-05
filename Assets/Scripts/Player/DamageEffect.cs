using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DamageEffect : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSound;

    public void OnDamaged()
    {
        AudioSource.PlayClipAtPoint(_shootSound, transform.position, 1f);
    }
}
