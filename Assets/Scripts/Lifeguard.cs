using UnityEngine;
using UnityEngine.AI;


public class Lifeguard : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private SpriteRenderer sprite;
    private Animator animator;

    GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();


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
        if (gm.getState() == GameManager.GameStates.Game) {
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

            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    GameManager.GetInstance().UpdateBar("Vecinos", -0.2f);
            //}

            //if (Input.GetKeyDown(KeyCode.V))
            //{
            //    GameManager.GetInstance().UpdateBar("Vecinos", 0.1f);
            //}

            CheckPosition();
        }
    }
}
