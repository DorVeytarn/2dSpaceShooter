using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tilt;
    [SerializeField] Joystick _joystick;

    [SerializeField] private float _downBodrder;
    [SerializeField] private float _upBodrder;
    [SerializeField] private float _leftBodrder;
    [SerializeField] private float _rightBodrder;

    private Rigidbody _rigidbody;
    private float _moveHorizontal;
    private float _moveVertical;
    private Vector2 _movement;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Application.isMobilePlatform)
        {
            _moveHorizontal = _joystick.MovementVector.x;
            _moveVertical = _joystick.MovementVector.y;
        }
        else
        {
            _moveHorizontal = Input.GetAxis("Horizontal");
            _moveVertical = Input.GetAxis("Vertical");
        }

        Move(_moveHorizontal, _moveVertical, _tilt);
    }

    private void Move(float moveHorizontal, float moveVertical, float tilt)
    {
        _movement = new Vector2(moveHorizontal, moveVertical);
        _rigidbody.velocity = _movement * _speed;

        _rigidbody.transform.rotation = Quaternion.Euler(_rigidbody.velocity.y * tilt * 1.5f, _rigidbody.velocity.x * -tilt, _rigidbody.velocity.x * -tilt * 0.8f);

        ChekPlayerPosition();
    }    

    private void ChekPlayerPosition()
    {
        _rigidbody.position = new Vector2 (Mathf.Clamp(_rigidbody.position.x, _leftBodrder, _rightBodrder),Mathf.Clamp(_rigidbody.position.y, _downBodrder, _upBodrder));
    }
}
