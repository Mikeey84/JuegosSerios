using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCpath : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private SpriteRenderer sprite;
    private Animator animator;

    private AccidenteComponent ac;

    public bool stop = false;
    public bool lesion;
    private int  i = 1;

    [SerializeField] private Vector3[] path;

    [SerializeField] private int npaths;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ac = GetComponent<AccidenteComponent>();


    }
    void setDest()
    {
        
        if (agent.pathPending)return;
        if (agent.remainingDistance <= agent.stoppingDistance )
        {
            if (i < npaths - 1)
            {
                i++;
                agent.SetDestination(path[i]);
                sprite.flipX = path[i].x < transform.position.x;
            }
            else
            {
                animator.SetBool("Moving", false);
                if (lesion)
                {
                    if (transform.childCount > 0)
                    {
                        Debug.Log("a");
                        transform.GetChild(0).gameObject.SetActive(true);
                    }
                    ac.enabled=true;

                }
            }

        }

    }
    public void move()
    {
        animator.SetBool("Moving", true);
        agent.SetDestination(path[0]);
        sprite.flipX = path[0].x < transform.position.x;
        stop = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (stop)
        {

            setDest();

        }
    }
}
