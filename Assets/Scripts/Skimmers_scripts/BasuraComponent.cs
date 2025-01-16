using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraComponent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            GetComponentInParent<SkimmersManager>().erase();
        }
    }
}
