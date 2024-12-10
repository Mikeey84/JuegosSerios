using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundido : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private Animator anim;
    private bool activar=true;
    private GameObject gObject;

    void Start()
    {
        gObject = gameObject.GetComponent<GameObject>();
        anim = GetComponentInParent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //UIManager.instance.hideObjects();
        GameManager.GetInstance().setState(GameManager.GameStates.Manual);
    }

    // Update is called once per frame
    void Update()
    {
        if (activar)
        {


            if (DialogManager.Instance.fin())
            {
                GameManager.GetInstance().setState(GameManager.GameStates.Manual);
                anim.SetBool("Trans", true);
                activar = false;

            }
        }

    }
    public void active()
    {
        activar = true;
    }
    public void setInactive()
    {
        Debug.Log("adri");
        anim.SetBool("Trans", false);
        gameObject.SetActive(false);
        GameManager.GetInstance().initLevel(0);
        GameManager.GetInstance().setState(GameManager.GameStates.Game);


    }
}
