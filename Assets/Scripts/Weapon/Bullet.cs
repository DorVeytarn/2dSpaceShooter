using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            //enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
