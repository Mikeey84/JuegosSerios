using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LluviaController : MonoBehaviour
{
    [SerializeField] GameObject lluvia;
    [SerializeField] GameObject Cerrar;
    private float remainingtime;
    private float elapsedtime;
    // Start is called before the first frame update
    void Start()
    {
        elapsedtime = 0;
        remainingtime = Random.Range(13.5f, 20.5f);
}

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;
        if(elapsedtime >remainingtime  ) {
            lluvia.SetActive(true);
            Cerrar.SetActive(true);
            Debug.Log("empieza");
        }
    }
}
