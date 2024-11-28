using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCpath : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private SpriteRenderer sprite;
    private Animator animator;


    private bool stop = false;
    private bool next = false;
    private int  i = 1;
    [SerializeField] private Vector3[] path;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", true);
        agent.SetDestination(path[0]);
        sprite.flipX = path[i].x < transform.position.x;
    }
    void setDest()
    {
        
        if (agent.pathPending)return;
        if (agent.remainingDistance <= agent.stoppingDistance )
        {
            if (i < 5 - 1)
            {
                i++;
                agent.SetDestination(path[i]);
                sprite.flipX = path[i].x < transform.position.x;
            }
            else
            {
                animator.SetBool("Moving", false);

            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        setDest();
    }
}
