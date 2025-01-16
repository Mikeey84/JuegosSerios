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
        if (GameManager.GetInstance().vecinosBar.fillAmount <= 0) SceneManager.LoadScene("FinalMalo");
        if (GameManager.GetInstance().empresaBar.fillAmount <= 0) SceneManager.LoadScene("FinalMalo");
        Debug.Log(name);
        //gm.setState(GameManager.GameStates.PH);
        SceneManager.LoadScene(name);
    }
    public void Fin(string name)
    {

        Debug.Log(name);
        gm.setState(GameManager.GameStates.PH);
        if (GameManager.GetInstance().empresaBar.fillAmount <= 0) SceneManager.LoadScene("FinalMalo");
        else if (GameManager.GetInstance().vecinosBar.fillAmount <= 0) SceneManager.LoadScene("FinalMalo");
        else SceneManager.LoadScene(name);
    }
}
