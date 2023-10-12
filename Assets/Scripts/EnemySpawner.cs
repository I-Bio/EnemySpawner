using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnTime;
    
    private Transform[] _points;
    private float _currentTime;
    
    private void Start()
    {
        CollectSpawnPoints();
    }

    private void Update()
    {
        Spawn();
    }

    private void CollectSpawnPoints()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    private void Spawn()
    {
        if (_currentTime >= _spawnTime)
        {
            var enemy = Instantiate(_template, GetRandomPointPosition(), Quaternion.identity);
            
            enemy.SetDirection(GetRandomPointPosition());
            _currentTime = 0f;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    private Vector3 GetRandomPointPosition()
    {
        return _points[Random.Range(0, _points.Length)].position;
    }
}
