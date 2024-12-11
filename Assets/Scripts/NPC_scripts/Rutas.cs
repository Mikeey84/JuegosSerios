
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rutas : MonoBehaviour
{
    // Start is called before the first frame update
    private UnityEngine.AI.NavMeshAgent agent;
    private SpriteRenderer sprite;
    private Animator animator;

    [SerializeField] private int npaths;

    private int i;
    public bool rutaterminada;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        i = 0;
        rutaterminada = false;
        Vector3 aux = new Vector3(Random.Range(-5f, 10f), Random.Range(-5f, 10f), 0);
        agent.SetDestination(aux);
        sprite.flipX = aux.x < transform.position.x;
        animator.SetBool("move", true);
    }

    void setDest()
    {

        if (agent.pathPending) return;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (i < npaths - 1)
            {
                i++;
                Vector3 aux = new Vector3(Random.Range(-5f, 10f), Random.Range(-5f, 10f), 0);
                agent.SetDestination(aux);
                sprite.flipX = aux.x < transform.position.x;
            }
            else
            {
                animator.SetBool("move", false);
                rutaterminada = true;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!rutaterminada) {
            setDest();
        }

    }
}
