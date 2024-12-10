using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] bool startConversation;
    [SerializeField] string _messageID;
    [SerializeField] private string _correctConversation;
    [SerializeField] private string _wrongConversation;
    [SerializeField] private GameObject _activateAfterConversation;
    LeerDatos LeerDatos;
    // metodo que se llama para crear el dialogo

    private void Start()
    {
        LeerDatos = GetComponent<LeerDatos>();

        int selectedAnswer = GameManager.GetInstance().GetSelectedAnswer();
        string messageID;

        if (selectedAnswer != -1)
        {
            if (selectedAnswer == 1) messageID = _correctConversation; // gestionar bien qué toca
            else messageID = _wrongConversation;
            GameManager.GetInstance().SetSelectedAnswer(-1);
            _messageID = messageID;
        }

        string[] aux = LeerDatos.MostrarMensajes(_messageID);

        foreach (string a in aux)
        {
            dialog.Lines.Add(a);
        }

        if (startConversation)
        {
            DialogManager.Instance.setObject(_activateAfterConversation);
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
