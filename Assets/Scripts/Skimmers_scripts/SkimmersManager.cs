using System.Collections.Generic;
using UnityEngine;

public class SkimmersManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _list;
    [SerializeField] private GameObject _activarAlAcabar;
    private int _numHojas;
    // Start is called before the first frame update
    void Start()
    {
        _numHojas = _list.Count;
        Debug.Log(_numHojas);
    }

    // Update is called once per frame
    void Update()
    {
        if (_numHojas == 0 && _activarAlAcabar != null && _activarAlAcabar.activeInHierarchy == false)
        {
            _activarAlAcabar.SetActive(true);
            Debug.Log("ACTIVA");
        }
    }
    public void erase()
    {
        _numHojas--;
    }
}
