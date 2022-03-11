using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    private Vector2 _offset;

    private bool _dragging;

    void Update()
    {
        if (_dragging == false)
            return;

        Vector2 mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;

    }

    Vector2 GetMousePos() => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void OnMouseDown()
    {
        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            _gameManager.CircleDestroyed();
            Destroy(collision.gameObject);
        }
    }

}
