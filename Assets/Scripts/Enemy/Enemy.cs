using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplayDamage(_damage);
            Die();
        }
        else if (other.TryGetComponent(out Destroyer destroyer))
            Die();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
