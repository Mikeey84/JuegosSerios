using UnityEngine;
using UnityEngine.AI;

public class Lifeguard : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private bool tieneBotiquin;

    // Start is called before the first frame update
    void Start()
    {
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
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
