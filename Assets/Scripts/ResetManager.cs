using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().UpdateBar("Vecinos", 1);   
        GameManager.GetInstance().UpdateBar("Empresa", 1);   
    }
}
