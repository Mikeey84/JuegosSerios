using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenManual : MonoBehaviour
{
    [SerializeField] GameObject manual;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Abrir() 
    {
        if (manual != null)
        {
            gm.setState(GameManager.GameStates.Manual);
            manual.SetActive(true);
        }
    }
}
