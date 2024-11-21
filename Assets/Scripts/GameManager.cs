using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // instancia del GameManager
    
    [SerializeField] private GameObject uiPrefab; // prefab de la interfaz
    private GameObject uiInstance; // instancia de la interfaz

    private Image vecinosBar; // barra de los vecinos
    private Image empresaBar; // barra de la empresa

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        // Instancia la interfaz al iniciar el GameManager
        uiInstance = Instantiate(uiPrefab);
        DontDestroyOnLoad(uiInstance);
        
        // Encuentra las barras dentro del prefab
        vecinosBar = uiInstance.transform.Find("Vecinos/Barra").GetComponent<Image>();
        empresaBar = uiInstance.transform.Find("Empresa/Barra").GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
                if (vecinosBar.fillAmount < 0) ;
                break;
            case "Empresa":
                empresaBar.fillAmount += value;
                if (empresaBar.fillAmount < 0) ;
                break;
            default:
                Debug.LogWarning($"Barra {barName} no encontrada");
                break;
        }
    }

    /// <summary>
    /// Método de obtención del GameManager en la escena
    /// </summary>
    /// <returns>GameManager de la escena</returns>
    public static GameManager GetInstance() { return instance; }
}
