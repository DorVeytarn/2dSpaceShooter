using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Weapon _weapon;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _secondsBetweenShoot;

    private int _currenthealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public UnityEvent ReceivedDamage;


    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _currenthealth = _maxHealth;

        StartCoroutine(ShootWithDelay(_shootPoint, _secondsBetweenShoot));
        HealthChanged?.Invoke(_currenthealth);
    }

    public void ApplayDamage(int damage)
    {
        ReceivedDamage?.Invoke();

        _currenthealth -= damage;
        HealthChanged?.Invoke(_currenthealth);

        if (_currenthealth <= 0)
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
