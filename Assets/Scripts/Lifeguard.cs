using UnityEngine;
using UnityEngine.AI;


public class Lifeguard : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;
    private bool tieneBotiquin;
    private bool drch=true;
    private double dest = 0.0;
    private Transform transform;
    private SpriteRenderer sprite;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        mainCamera = Camera.main;

        tieneBotiquin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Detectar si el clic izquierdo del ratón es presionado
        if (Input.GetMouseButtonDown(0))  // 0 corresponde al clic izquierdo
        {
            RaycastHit hit;
            Debug.Log(agent.speed);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                animator.SetBool("Moving", true);
                agent.SetDestination(hit.point);
                dest = hit.point.x;
                Debug.Log(hit.point.x);
                sprite.flipX = hit.point.x < transform.position.x;
            }

        }
        else
        {
            Debug.Log(dest + " "+transform.position.x);
            if (transform.position.x == dest)
            {
                animator.SetBool("Moving", false);

            }
        }
 


    }
}
