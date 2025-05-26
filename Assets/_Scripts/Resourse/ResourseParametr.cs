using UnityEngine;

public class ResourseParametr : MonoBehaviour
{
    public static ResourseParametr Instance { get; private set; }

    [SerializeField] private ResourseSpawn _resourseSpawn;

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


    public Vector2 DeterminingNearestResource(Transform transform)
    {
        float currentDistance;
        float minDistance = Vector2.Distance(_resourseSpawn.Resourses[0].transform.position, transform.position);
        Vector2 targetPosition = _resourseSpawn.Resourses[0].transform.position;
        foreach (var resours in _resourseSpawn.Resourses)
        {
            if(resours.gameObject.activeSelf == true&&resours.IsBusy == false)
            {
                currentDistance = Vector2.Distance(resours.transform.position, transform.position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    targetPosition = resours.transform.position;
                }
            }
           
        }
        return targetPosition;
    }
}
