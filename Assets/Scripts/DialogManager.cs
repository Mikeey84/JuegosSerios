using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject _dialogBox;
    [SerializeField] Text _dialogText;
    [SerializeField] int _letPerScnd;
    [SerializeField] Dialog _dialog;
    [SerializeField] int _currentLine = 0;
    [SerializeField] bool _typing;
    
    // Para activar el boton de la pantalla
    [SerializeField] GameObject _button;
    private GameObject _skip;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    public void ShowDialog(Dialog dialog)
    {
        this._dialog = dialog;
        _dialogBox.SetActive(true);
        StartCoroutine(Type(dialog.Lines[0]));
    }
    public void disableDialog()
    {
        _dialogBox.SetActive(false);
    }

    public IEnumerator Type(string line)
    {
        _typing = true;
        _dialogText.text = "";
        int aux = _letPerScnd;
        foreach (var l in line.ToCharArray())
        {
            _dialogText.text += l;
            yield return new WaitForSeconds(1f / _letPerScnd);
        }
        _typing = false;
    }

    private void Update()
    {
        if (_dialogBox.activeSelf)
        {
            if (!_typing && Input.GetKeyDown(KeyCode.Space))
            {
                ++_currentLine;
                if (_currentLine < _dialog.Lines.Count)
                {
                    StartCoroutine(Type(_dialog.Lines[_currentLine]));
                }
                else
                {
                    _currentLine = 0;
                    _dialogBox.SetActive(false);

                    if (_button != null)
                    {
                        _button.SetActive(true);
                    }
                }
            }
            // Si el texto está siendo escrito y se presiona espacio, saltar al final
            else if (_typing && Input.GetKeyDown(KeyCode.Space))
            {
                StopAllCoroutines();  // Detener cualquier corrutina que esté escribiendo el texto
                _dialogText.text = _dialog.Lines[_currentLine];  // Mostrar el texto completo
                _typing = false;

            }
        }
    }
}
