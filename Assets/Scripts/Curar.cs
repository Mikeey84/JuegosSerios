using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [SerializeField] GameObject gasa;
    [SerializeField] GameObject suero;
    [SerializeField] GameObject raja;
    [SerializeField] GameObject mierda;
    [SerializeField] GameObject flecha;
    private bool error;
    // Start is called before the first frame update
    void Start()
    {
        error = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null&&collision.gameObject==suero)
        {
            if (mierda != null && mierda.gameObject.active)
            {
                mierda.SetActive(false);
            }

        }
        else
        {
            if (collision.gameObject == gasa)
            {
                if (!mierda.gameObject.active)
                {
                    raja.SetActive(false);
                    flecha.SetActive(true);
                    DialogManager.Instance.ShowMessage("HeridaCurada");
                }
                else
                {
                    if (!error)
                    {
                        Debug.Log("ee");
                        GameManager.GetInstance().UpdateBar("Vecinos", -0.25f);
                        error = true;
                    }
                }
            }
        }
    }
}
