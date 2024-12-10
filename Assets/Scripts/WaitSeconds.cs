using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] float _seconds;

    private void Start()
    {
        StartCoroutine(ActivateAfterTime(_seconds)); 
    }

    private IEnumerator ActivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (_object != null)
        {
            _object.SetActive(true);
        }
    }
}
