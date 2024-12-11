using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] npcs;
    private int cont;
    private bool spawn;
    void Start()
    {
        spawn = true;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            if (DialogManager.Instance.fin())
            {
                Instantiate(npcs[cont]);
                cont++;
                spawn = false;
            }


        }
    }
    public void active()
    {
        spawn = true;
    }
}
