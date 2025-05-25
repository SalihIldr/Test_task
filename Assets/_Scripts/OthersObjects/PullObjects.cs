using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour
{
    public static PullObjects Instance { get; private set; }

    [SerializeField] private List<SpawnObject> _pullObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }       
    }

    public List<SpawnObject> DetectSpawnedObjects(TypeSpawnObjects typeSpawnObjects)
    {
       List<SpawnObject> objects = new List<SpawnObject>();
        foreach (var spawnObject in _pullObjects)
        {
            if (spawnObject.gameObject.activeSelf == false && spawnObject.TypeSpawnObject == typeSpawnObjects)
            {                
                objects.Add(spawnObject);
            }
        }
        return objects;
    }

    public void DissaperObject(SpawnObject spawnObject)
    {
        spawnObject.Disappear();
    }

}
