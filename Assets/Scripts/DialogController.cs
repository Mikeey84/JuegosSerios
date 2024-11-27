using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] bool startConversation;
    [SerializeField] string _messageID;
    LeerDatos LeerDatos;
    // metodo que se llama para crear el dialogo

    private void Start()
    {
        LeerDatos = GetComponent<LeerDatos>();
        string[] aux = LeerDatos.MostrarMensajes(_messageID);

        foreach (string a in aux)
        {
            dialog.Lines.Add(a);
        }
        if (startConversation)
        {
            DialogManager.Instance.ShowDialog(dialog);
        }
    }

    private void Update()
    {

    }

    public void ShowDialog()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
}
