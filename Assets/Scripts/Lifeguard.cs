using UnityEngine;
using UnityEngine.AI;


public class Lifeguard : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        mainCamera = Camera.main;
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
                sprite.flipX = hit.point.x < transform.position.x;
            }
        }

        CheckPosition();
    }
}
