using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Transform[] _points;
    private int _currentPoint;
    
    private void Start()
    {
        
    }
    
    public void Update()
    {
        Move();
    }
    
    public void SetFields(Transform[] points, int currentPoint)
    {
        _points = points;
        _currentPoint = currentPoint;
    }

    private void Move()
    {
        Transform target = _points[_currentPoint];

        transform.position =  Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
