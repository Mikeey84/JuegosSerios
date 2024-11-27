using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBackGround : MonoBehaviour
{
    [SerializeField] GameManager.GameStates state;
    [SerializeField] GameObject manual;
    [SerializeField] GameObject boton;

    [SerializeField] private GameObject uiPrefab;

    PolygonCollider2D collider;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        collider = GetComponent<PolygonCollider2D>();
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
                manual.SetActive(false);
                uiPrefab.SetActive(true);

                boton.SetActive(true);

                gm.setState(state);

            }
        }
    }

}
