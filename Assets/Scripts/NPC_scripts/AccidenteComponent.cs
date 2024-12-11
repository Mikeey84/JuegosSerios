using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidenteComponent : MonoBehaviour
{
    public bool ac;
    private CircleCollider2D collider;

    [SerializeField] GameObject multiO;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();

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

            if (hit.collider == collider) // Verifica si el raycast impactó algo
            {
                Debug.Log("hit");
                if (multiO != null)
                {
                    //multiO.SetActive(true);
                   Instantiate(multiO);
                }
            }
        }
    }
}
