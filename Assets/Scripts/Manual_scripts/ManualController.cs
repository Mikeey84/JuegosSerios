using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    [SerializeField] private GameObject _goBack; // Boton para retroceder
    [SerializeField] private GameObject _goForward; // Boton para avanzar

    [SerializeField] private List<GameObject> _pagesElements;

    private int _numPage;
    private int _currentPage;

    public void ActivateManual()
    {
        _numPage = _pagesElements.Count;
        _currentPage = 0;

        foreach (var page in _pagesElements)
        {
            page.SetActive(false);
        }

        StartCoroutine(ActivatePageWithDelay(0));
    }
    private IEnumerator ActivatePageWithDelay(int pageIndex)
    {
        yield return new WaitForSeconds(0.7f); 

        _pagesElements[pageIndex].SetActive(true);

        UpdateButtons();
    }
    public void GoForward()
    {
        if (_currentPage < _numPage - 1)
        {
            
            _pagesElements[_currentPage].SetActive(false);

            _currentPage++;

            _pagesElements[_currentPage].SetActive(true);

            UpdateButtons();
        }
    }
    public void GoBack()
    {
            if (_currentPage > 0)
            {
                _pagesElements[_currentPage].SetActive(false);

                _currentPage--;

                _pagesElements[_currentPage].SetActive(true);

                UpdateButtons();
            }
    }
    private void UpdateButtons()
    {
        _goBack.SetActive(_currentPage > 0);
        _goForward.SetActive(_currentPage < _numPage - 1);
    }
}
