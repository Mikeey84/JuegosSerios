using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Salto : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 destino;
    private Vector3 trayec;
    void Start()
    {
        Vector3 aux = gameObject.transform.position;
        trayec = destino -aux;
        trayec=trayec.normalized;
        gameObject.GetComponent<SpriteRenderer>().flipX = destino.x < transform.position.x;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destino.x-0.5&& transform.position.x > destino.x + 0.5&& transform.position.y < destino.y - 0.5 && transform.position.y > destino.y + 0.5)
        {
            transform.position += trayec * 0.01f;

        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponent<Rutas>().enabled = true;
            gameObject.GetComponent<Animator>().SetBool("salto",true);
            this.enabled = false;
        }
    }
}
