using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionComponent : MonoBehaviour
{
    public int Respuesta;
    LeerDatos LeerDatos;
    [SerializeField]  Dialog dialog;

    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private GameObject flecha;
    // Start is called before the first frame update
    void Start()
    {
        LeerDatos = GetComponent<LeerDatos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMessage(string id)
    {
        string[] aux = LeerDatos.MostrarMensajes(id);

        foreach (string a in aux)
        {
            dialog.Lines.Add(a);
        }
        DialogManager.Instance.ShowDialog(dialog);
        flecha.SetActive(true);

    }

    public void solucion(int opcion)
    {
        if(opcion==Respuesta)
        {
            uiPrefab.SetActive(false);
            ShowMessage("AciertoPH");
        }
        else
        {
            uiPrefab.SetActive(false);

            ShowMessage("ErrorPH");
        }
    }

}
