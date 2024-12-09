using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundido : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //UIManager.instance.hideObjects();
        GameManager.GetInstance().setState(GameManager.GameStates.Manual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
