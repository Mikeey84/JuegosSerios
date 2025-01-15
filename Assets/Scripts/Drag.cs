using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{
    private BoxCollider2D col;
    private bool _isDragging;
    private Camera _mainCamera;
    private Transform _transform;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        col=this.GetComponent<BoxCollider2D>();
        _mainCamera = Camera.main;
        _isDragging = false;
        _transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 0 corresponde al clic izquierdo
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Debug.Log(hit.collider);
            //Debug.Log(collider);

            if (hit.collider == col) // Verifica si el raycast impactó algo
            {
                Debug.Log("cogido");
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
            //Debug.Log(GetMouseWorldPosition());
            _transform.position= GetMouseWorldPosition()+_offset;
            Debug.Log(_transform.position);

        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        return _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
