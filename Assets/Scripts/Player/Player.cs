using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _secondsBetweenShoot;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        StartCoroutine(ShootWithDelay(_shootPoint, _secondsBetweenShoot));
        HealthChanged?.Invoke(_health);
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private IEnumerator ShootWithDelay(Transform shootPoint, float secondsBetweenShoot)
    {
        while (true)
        {
            _weapon.Shoot(shootPoint);
            yield return new WaitForSeconds(secondsBetweenShoot);
        }
    }

    private void Die()
    {
        StopCoroutine("ShootWithDelay");
        Died?.Invoke();
    }
}
