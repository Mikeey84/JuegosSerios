using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionComponent : MonoBehaviour
{
    public int Respuesta;
    LeerDatos LeerDatos;
    [SerializeField]  Dialog dialog;
    [SerializeField] string _rightAnswerConversation;
    [SerializeField] string _wrongAnswerConversation;
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
        if(flecha!=null)flecha.SetActive(true);

    }

    public void solucion(int opcion)
    {
        if(opcion==Respuesta)
        {
            if(uiPrefab!=null)uiPrefab.SetActive(false);
            ShowMessage(_rightAnswerConversation);
        }
        else
        {
            if (uiPrefab != null) uiPrefab.SetActive(false);

            ShowMessage(_wrongAnswerConversation);
        }
    }

}
