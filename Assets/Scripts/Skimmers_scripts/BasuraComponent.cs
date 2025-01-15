using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraComponent : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (_audio != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(_audio);
            }

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            GetComponentInParent<SkimmersManager>().erase();
        }
    }
}
