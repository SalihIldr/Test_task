using UnityEngine;

public abstract class SpawnObject : MonoBehaviour
{
    [field: SerializeField] public TypeSpawnObjects TypeSpawnObject { get; private set; }

    Vector2 _returnPosition;

    private void Start()
    {
        _returnPosition = transform.position;
    }

    public void Spawn(Vector2 spawnPosition)
    {
        gameObject.transform.position = spawnPosition;
        gameObject.SetActive(true);
    }

    public void Disappear()
    {       
        gameObject.SetActive(false);
        gameObject.transform.position = _returnPosition;
    }
}
