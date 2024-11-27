using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarDecision : MonoBehaviour
{
    [SerializeField] GameObject multiO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Decision()
    {
        if (multiO != null)
        {
            multiO.SetActive(true);
        }
    }
}
