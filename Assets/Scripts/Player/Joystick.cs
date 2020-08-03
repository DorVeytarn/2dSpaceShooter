using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _stick;

    private Vector2 _movementVector;
    private Vector2 _touchPosition;

    public Vector2 MovementVector => _movementVector;

    private void Start()
    {
        _joystick = GetComponent<Image>();
        _stick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _movementVector = Vector2.zero;
        _stick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.rectTransform, eventData.position, eventData.pressEventCamera, out _touchPosition))
        {
            _touchPosition.x = _touchPosition.x / _joystick.rectTransform.sizeDelta.x;
            _touchPosition.y = _touchPosition.y / _joystick.rectTransform.sizeDelta.y;

            _movementVector = new Vector2(_touchPosition.x * 2, _touchPosition.y * 2);

            _movementVector = (_movementVector.magnitude > 1f) ? _movementVector.normalized : _movementVector;

            _stick.rectTransform.anchoredPosition = new Vector2(_movementVector.x * (_joystick.rectTransform.sizeDelta.x / 2), _movementVector.y * (_joystick.rectTransform.sizeDelta.y / 2));
        }
    }
}
