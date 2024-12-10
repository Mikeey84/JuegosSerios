using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    private SManager _sManager;
    private void Start()
    {
        _sManager = GetComponent<SManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Lifeguard>())
        {
            _sManager.changeScene("Pinchazo");
        }
    }
}
