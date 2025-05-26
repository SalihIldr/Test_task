using UnityEngine;

public class DroneSpawnPoint : MonoBehaviour
{
    [field: SerializeField] public Sprite SpriteDron { get; private set; }
    [field: SerializeField] public Transform BaseTransform { get; private set; }
}
