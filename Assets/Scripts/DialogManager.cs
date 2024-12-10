using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] LeerDatos LeerDatos;
    [SerializeField] GameObject _dialogBox;
    [SerializeField] GameObject npcs;
    [SerializeField] Text _dialogText;
    [SerializeField] int _letPerScnd;
    [SerializeField] Dialog _dialog;
    [SerializeField] int _currentLine = 0;
    [SerializeField] bool _typing;

    GameManager _gM;
    [SerializeField] GameManager.GameStates _postState;

    // Para activar el boton de la pantalla
    [SerializeField] GameObject _button;
    private GameObject _skip;
    public bool acabado = false;
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gM = GameManager.GetInstance();
    }

    public void ShowDialog(Dialog dialog)
    {
        acabado = false;
        this._dialog = dialog;
        _dialogBox.SetActive(true);
        if(_gM != null)
            _gM.setState(GameManager.GameStates.Manual);
        StartCoroutine(Type(dialog.Lines[0]));
    }
    public void ShowMessage(string id)
    {
        
        string[] aux = LeerDatos.MostrarMensajes(id);
        _dialog.reset();
        foreach (string a in aux)
        {
            _dialog.Lines.Add(a);
        }
        ShowDialog(_dialog);

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
                    acabado = true;
                    _gM.setState(_postState);
                    if (_button != null)
                    {
                        _button.SetActive(true);
                    }
                    if (npcs != null)
                    {
                        int aux = npcs.transform.childCount;
                        for (int i = 0; i < aux; i++)
                        {
                            npcs.transform.GetChild(i).GetComponent<NPCpath>().move();
                        }
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

    public bool end()
    {
        return _dialogBox.activeSelf;
    }
    public bool fin()
    {
        return acabado;
    }
    public void setObject(GameObject gameObject)
    {
        _button = gameObject;
    }
}
