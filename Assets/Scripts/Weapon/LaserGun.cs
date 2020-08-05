using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private AudioClip _shootSound;
   
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_shootSound, transform.position, 2f);
    }
}
