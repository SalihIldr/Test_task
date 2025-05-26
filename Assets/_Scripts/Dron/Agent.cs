using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private Vector2 _targetPosition;
    NavMeshAgent _agent;

    bool _isReturn = false;
    bool _isStop = false;

    public bool IsReturn => _isReturn;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(_isStop == false)
        {
            if (_isReturn == false)
                SetTargetResourse();
            SetAgentPosition();
        }
       
    }

    private void SetTargetResourse()
    {
        _targetPosition =  ResourseParametr.Instance.DeterminingNearestResource(transform);
    }

    public void StartResoursCollect()
    {
        _isReturn = false;
        SetTargetResourse();
    }

    public void Return(Vector2 targetPosition)
    {
        _isStop = false;
        _isReturn = true;       
        _targetPosition = targetPosition;
    }

    public void Collected()
    {
        _isStop = true;
    }

    private void SetAgentPosition()
    {
        _agent.SetDestination(new Vector2(_targetPosition.x, _targetPosition.y));
    }
}
