using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] Dialog dialog;

    LeerDatos LeerDatos;
    // metodo que se llama para crear el dialogo

    private void Start()
    {
        LeerDatos = GetComponent<LeerDatos>();
        string[] aux = LeerDatos.MostrarMensajes("Entrevistador");

        foreach (string a in aux)
        {
            dialog.Lines.Add(a);
        }
        DialogManager.Instance.ShowDialog(dialog);
    }
}
