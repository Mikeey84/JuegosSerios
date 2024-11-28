using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SManager : MonoBehaviour
{
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
    public void changeScene(string name)
    {

        Debug.Log(name);
        //gm.setState(GameManager.GameStates.PH);
        SceneManager.LoadScene(name);
    }
}
