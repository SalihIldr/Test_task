using UnityEngine;

public class Dron : SpawnObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Agent _agent;

    private Transform _baseTransform;

    public void Init(Sprite spriteDron, Transform baseTransform)
    {
        _spriteRenderer.sprite = spriteDron;
        _baseTransform = baseTransform;
    }

    public void StartCollectResourse(Resourse resourse)
    {
        if(_agent.IsReturn == false)
        {
            _agent.Collected();
            resourse.Collected += CollectedResourse;
        }
       
    }

    private void CollectedResourse(Resourse resourse)
    {
        resourse.Collected -= CollectedResourse;
        _agent.Return(_baseTransform.transform.position);
        
    }

    public void SubmittedResource()
    {
        _agent.StartResoursCollect();
    }
}
