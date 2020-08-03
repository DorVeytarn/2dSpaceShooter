using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tumble;

    private Rigidbody _rigidbody;

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
}
