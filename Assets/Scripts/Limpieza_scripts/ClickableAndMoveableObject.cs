using UnityEngine;

public class ClickableAndMoveableObject : MonoBehaviour
{
    private Collider2D col;

    private bool isDragging = false;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar clic izquierdo y si el ratón está sobre el collider
        if (Input.GetMouseButtonDown(0) && MouseInMopSurface())
        {
            // Inicia el movimiento arrastrando
            isDragging = true;

            // Calcula el offset (diferencia) entre la posición del objeto y la posición del ratón
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = (Vector2)transform.position - mousePosition;
        }

        // Detectar cuando se suelta el clic izquierdo
        if (Input.GetMouseButtonUp(0))
        {
            // Finaliza el movimiento
            isDragging = false;
        }

        // Si estamos arrastrando el objeto
        if (isDragging)
        {
            // Actualizar la posición del objeto según la posición del ratón y el offset
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    bool MouseInMopSurface()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (col != null)
        {
            return col.OverlapPoint(mousePosition);
        }

        return false;
    }
}
