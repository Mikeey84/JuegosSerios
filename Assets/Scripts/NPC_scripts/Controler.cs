using UnityEngine;

public class Controler : MonoBehaviour
{
    // Start is called before the first frame update
    private Rutas rutas;
    private AccidenteComponent ac;
    private Animator animator;
    public string animAccidente;
    void Start()
    {
        animator = GetComponent<Animator>();
        rutas =gameObject.GetComponent<Rutas>();
        ac=gameObject.GetComponent<AccidenteComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rutas.rutaterminada&&!ac.enabled)
        {
            ac.enabled = true;
            animator.SetBool(animAccidente, true);
        }
    }
    public void activarNado()
    {
        rutas.enabled = true;
        animator.SetBool("nadar", true);
    }
}
