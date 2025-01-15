using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject _activar;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Lifeguard>() != null &&
            collision.gameObject.GetComponent<Lifeguard>().IsGrabbing())
        {
            _activar.SetActive(true);
        }
    }
}
