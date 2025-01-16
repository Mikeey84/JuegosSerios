using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStates _gameStates;
    public enum GameStates
    {
        Game, PauseMenu, Manual, PH, Cleaning
    }

    private static GameManager instance; // instancia del GameManager
    
    [SerializeField] private GameObject uiPrefab; // prefab de la interfaz
    [SerializeField] private GameObject npcManager; // prefab de la interfaz

    private GameObject uiInstance; // instancia de la interfaz

    public Image vecinosBar; // barra de los vecinos
    public Image empresaBar; // barra de la empresa

    private GameStates currentState;

    private int _selectedAnswer;

   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Asegúrate de no destruir todo el GameObject
            
            // Instancia la interfaz al iniciar el GameManager
            uiInstance = Instantiate(uiPrefab);
            DontDestroyOnLoad(uiInstance);

            // Encuentra las barras dentro del prefab
            vecinosBar = uiInstance.transform.Find("Vecinos/Barra").GetComponent<Image>();
            empresaBar = uiInstance.transform.Find("Empresa/Barra").GetComponent<Image>();

            _selectedAnswer = -1;
        }
        else Destroy(gameObject);  // Destruir el GameObject completo, no solo el script
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = _gameStates;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameStates.Game)
        {
            uiInstance.SetActive(true);
            vecinosBar.enabled = true;
            empresaBar.enabled = true;
        }
        else if (currentState == GameStates.PH)
        {
            uiInstance.SetActive(false);
            vecinosBar.enabled = false;
            empresaBar.enabled = false;
        }
        else
        {
            uiInstance.SetActive(false);
            vecinosBar.enabled = false;
            empresaBar.enabled = false;
        }
    }

    /// <summary>
    /// Actualiza las barras de vecinos o comunidad según el valor `value`.
    /// Si este último es positivo suma, y si es negativo resta.
    /// </summary>
    /// <param name="barName">Nombre de la barra a acceder</param>
    /// <param name="value">Cantidad a sumar / restar de la barra</param>
    public void UpdateBar(string barName, float value)
    {
        switch (barName)
        {
            case "Vecinos":
                vecinosBar.fillAmount += value;
                Debug.Log(vecinosBar.fillAmount);
                if (vecinosBar.fillAmount > 1f) vecinosBar.fillAmount = 0;
                break;
            case "Empresa":
                empresaBar.fillAmount += value;
                if (vecinosBar.fillAmount > 1f) vecinosBar.fillAmount = 0;
                break;
            default:
                Debug.LogWarning($"Barra {barName} no encontrada");
                break;
        }
    }

    public void setState(GameStates state)
    {
        currentState = state;
    }

    public GameStates getState()
    {
        return currentState;
    }

    public int GetSelectedAnswer()
    {
        return _selectedAnswer;
    }

    public void SetSelectedAnswer(int newAnswer)
    {
        _selectedAnswer = newAnswer;
    }
    public void Wait(float t)
    {
        
        StartCoroutine(ActivateAfterTime(t));
    }

    private IEnumerator ActivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

    }
    public void initLevel(int i,string c)
    {
        if(npcManager!=null)
        {
            npcManager.GetComponent<NpcManager>().removeNpc(i);
            npcManager.GetComponent<NpcManager>().activeN();
        }
        if (c != null)
        {
            DialogManager.Instance.ShowMessage(c);
        }

    }
    /// <summary>
    /// Método de obtención del GameManager en la escena
    /// </summary>
    /// <returns>GameManager de la escena</returns>
    public static GameManager GetInstance() { return instance; }

}
