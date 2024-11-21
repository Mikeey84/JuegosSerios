using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsComponent : MonoBehaviour
{
    [SerializeField] GameObject UIbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Lifeguard>())
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<DialogController>().ShowDialog();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Lifeguard>())
        {

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Lifeguard>())
        {

        }
    }
}
