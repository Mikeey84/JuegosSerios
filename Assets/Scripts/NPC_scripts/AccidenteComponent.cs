using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccidenteComponent : MonoBehaviour
{
    public bool ac;
    private CircleCollider2D collider;
    [SerializeField] private string minijuego;
    [SerializeField] GameObject multiO;
    [SerializeField] GameObject conversation;
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

            if (hit.collider == collider) // Verifica si el raycast impact� algo
            {
                Debug.Log("hit");
                if(conversation != null)
                {
                    conversation.SetActive(true);
                }
                else
                {
                    if (multiO != null)
                    {
                        //multiO.SetActive(true);
                       Instantiate(multiO);
                    }
                    else
                    {
                        if (minijuego != null)
                        {
                            SceneManager.LoadScene(minijuego);
                            Debug.Log("rcp");
                        }
                    }

                }
            }
        }
    }
}
