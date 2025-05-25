using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseSpawn : MonoBehaviour
{
    [SerializeField] private int _startSpawnResourse = 5;
    [SerializeField] private float _areaSpawn = 4.7f;

    private List<Resourse> _resourses = new List<Resourse>();
    private WaitForSeconds _waitSecondSpawn;
   

    private void Start()
    {
        _waitSecondSpawn = new WaitForSeconds(2);
        DetectResourseObject();

        for (int i = 0; i < _startSpawnResourse; i++)
        {
            _resourses[i].Spawn(new Vector2(DetectRandomValue(), DetectRandomValue()));           
        }

        foreach (var resourse in _resourses)
        {
            resourse.Collected += HideResourse;
        }
        StartCoroutine(Spawn());
    }

    private float DetectRandomValue()
    {
        float randomValue = Random.Range(-_areaSpawn, _areaSpawn);
        return randomValue;
    }

    private void HideResourse(Resourse resourse)
    {
        resourse.Disappear();
        resourse.Collected -= HideResourse;
    }

    private void DetectResourseObject()
    {
        List<SpawnObject> spawnObjects = PullObjects.Instance.DetectSpawnedObjects(TypeSpawnObjects.Resours);
        Resourse resourseObject;
        foreach (var objects in spawnObjects)
        {
            resourseObject = objects.GetComponent<Resourse>();
            _resourses.Add(resourseObject);
        }
    }

    private IEnumerator Spawn()
    {       
        while (true)
        {           
            foreach (var resours in _resourses)
            {
                if (resours.gameObject.activeSelf == false)
                {
                    resours.Spawn(new Vector2(DetectRandomValue(), DetectRandomValue()));
                    break;
                }                   
            }
            yield return _waitSecondSpawn;
        }
    }
}
