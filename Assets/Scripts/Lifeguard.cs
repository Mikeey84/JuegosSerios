using UnityEngine;
using UnityEngine.AI;


public class Lifeguard : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private Transform transform;
    private SpriteRenderer sprite;

    private bool tieneBotiquin;

    private double dest = 0.0;


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

    void CheckPosition()
    {
        // Comprueba la distancia restante para detener la animación
        if (agent.pathPending) return; // Espera a que se calcule la ruta

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar si el clic izquierdo del ratón es presionado
        if (Input.GetMouseButtonDown(0))  // 0 corresponde al clic izquierdo
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null) // Verifica si el raycast impactó algo
            {
                animator.SetBool("Moving", true);
                agent.SetDestination(hit.point);
                dest = hit.point.x;
                sprite.flipX = hit.point.x < transform.position.x;
            }
        }

        CheckPosition();
    }
}
