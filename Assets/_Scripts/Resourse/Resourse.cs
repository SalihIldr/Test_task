using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Resourse : SpawnObject
{
    public event UnityAction<Resourse> Collected;

    private WaitForSeconds _waitSecondCollect = new WaitForSeconds(2);
    private Dron _currentDron = null;
    private bool _isBusy = false;
    public bool IsBusy => _isBusy; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Dron dron))
        {
            if(_currentDron == null)
            {
                _currentDron = dron;
                _isBusy = true;
                _currentDron.StartCollectResourse(this);
                StartCoroutine(EndCollected());
            }           
        }
    }

    private IEnumerator EndCollected()
    {

        yield return _waitSecondCollect;
        _currentDron = null;
        _isBusy = false;
        Collected?.Invoke(this);
    }

}
