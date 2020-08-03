using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _secondsBetweenShoot;

    private void Start()
    {
        StartCoroutine(ShootWithDelay(_shootPoint, _secondsBetweenShoot));
    }

    public void ApplayDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
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
}
