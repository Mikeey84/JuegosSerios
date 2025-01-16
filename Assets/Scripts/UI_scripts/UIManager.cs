using UnityEngine;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject[] canvas;
    [SerializeField] private GameObject fundido;
    [SerializeField] private GameObject Activefundido;
    private int celems;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        celems = canvas.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addObject(GameObject c)
    {
        canvas[celems] = c;
        celems++;
    }
    public void activeObjects()
    {
         foreach(GameObject obj in canvas)
        {
            obj.SetActive(true);
        }   
    }
    public void hideObjects()
    {
        foreach (GameObject obj in canvas)
        {
            obj.SetActive(false);
        }
    }
    public void Transition()
    {
        Debug.Log("ee");
        GameManager.GetInstance().setState(GameManager.GameStates.Manual);
        if(fundido!=null)Instantiate(fundido);
    }

}
