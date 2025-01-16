using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Compresiones : MonoBehaviour
{
    [SerializeField] GameObject manos;
    [SerializeField] GameObject flecha;
    private CircleCollider2D collide;
    private int totalcomp;
    public int comp;
    // Start is called before the first frame update
    void Start()
    {
        totalcomp = 0;
        comp = 0;
        collide = GetComponent<CircleCollider2D>();
        manos.SetActive(true);
    }
    public void active()
    {
        collide.enabled = true;
    }
    public void deactive()
    {
        collide.enabled = false;
        manos.GetComponent<Animator>().SetBool("compresiones", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (totalcomp <= 30)
        {
            if (Input.GetMouseButtonDown(0))  // 0 corresponde al clic izquierdo
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                //Debug.Log(hit.collider);
                //Debug.Log(collider);

                if (hit.collider == collide) // Verifica si el raycast impactó algo
                {
                    comp++;
                    Debug.Log(comp);
                    manos.GetComponent<Animator>().SetBool("compresiones", true);
                }
                else
                {

                    comp--;
                }
            }
        }
        else
        {
            if (comp >= 25)
            {
                DialogManager.Instance.ShowMessage("RCPBien");
            }
            else
            {
                GameManager.GetInstance().UpdateBar("Vecinos", -0.4f);
                DialogManager.Instance.ShowMessage("RCPMal");
            }
            manos.SetActive(false);
            flecha.SetActive(true);
            gameObject.SetActive(false);
           
        }

    }

    public void tempo()
    {
        totalcomp++;
        //collide.enabled = true;
    }

}
