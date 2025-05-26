using System.Collections.Generic;
using UnityEngine;

public class DroneSpawn : MonoBehaviour
{
    [SerializeField] private List<DroneSpawnPoint> _spawnPoints;

    

    private int _valueDronForFraction = 3;

    private List<Dron> _drones = new List<Dron>();

    private void Start()
    {
        DetectDroneSpawned();
        Spawn();      

    }

    private void DetectDroneSpawned()
    {
        List<SpawnObject> spawnObjects = PullObjects.Instance.DetectSpawnedObjects(TypeSpawnObjects.Dron);
        Dron droneObject;
        foreach (var objects in spawnObjects)
        {
            droneObject = objects.GetComponent<Dron>();
            _drones.Add(droneObject);
        }
    }

    private void Spawn()
    {
       int index = 0;
        for (int i = 0; i < _spawnPoints.Count; i++)
        {            
            for (int y = 0; y < _valueDronForFraction; y++)
            {               
                _drones[index].Init(_spawnPoints[i].SpriteDron, _spawnPoints[i].BaseTransform);
                _drones[index].Spawn(_spawnPoints[i].gameObject.transform.position);
                ++index;
                if(index == _drones.Count)
                {
                    Debug.Log("Нет свободных дронов");
                    break;
                }
            }
        }
    }
}
