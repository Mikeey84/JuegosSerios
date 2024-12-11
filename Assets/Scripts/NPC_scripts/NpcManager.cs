using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject npc1;
    [SerializeField]private GameObject npc2;
    void Start()
    {
        npc1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void removeNpc(int i)
    {
        if(i == 0)
        {
            Destroy(npc1);
        }
        else
        {
            Destroy(npc2);

        }
    }
    public void addNpc()
    {
       if(npc2!=null) npc2.SetActive(true);
    }
    public void activeN()
    {
        Instantiate(npc2);
        npc2.GetComponent<NPCpath>().move();
    }
}
