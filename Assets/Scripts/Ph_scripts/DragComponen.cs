using Unity.VisualScripting;
using UnityEngine;

public class DragObject2D : MonoBehaviour
{
    private bool _isDragging = false; 
    private Camera _mainCamera;      
    private Vector3 _offset;         
    private GameManager _gameManager;
    void Start()
    {
        _mainCamera = Camera.main;
        _gameManager = GameManager.GetInstance();
    }

    void Update()
    {
        if (_gameManager.getState() == GameManager.GameStates.Manual)
        {

            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();

            Collider2D collider = Physics2D.OverlapPoint(mousePosition);

            if (collider != null && collider.transform == transform)
            {
                _isDragging = true;

                _offset = transform.position - GetMouseWorldPosition();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }

        if (_isDragging)
        {
            transform.position = GetMouseWorldPosition() + _offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        return _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
