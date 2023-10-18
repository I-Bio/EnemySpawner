using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Target _template;
    
    private Transform[] _points;
    private List<Target> _targets;
    
    private void Awake()
    {
        _targets = new List<Target>();
        
        CollectSpawnPoints();
        SpawnTargets();
        SetTargetsForSpawners();
    }

    private void CollectSpawnPoints()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    private void SpawnTargets()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            var target = Instantiate(_template, _points[i].position, Quaternion.identity);
            
            target.SetFields(_points, i);
            _targets.Add(target);
        }
    }

    private void SetTargetsForSpawners()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            EnemySpawner enemySpawner = _points[i].GetComponent<EnemySpawner>();
            int targetIndex = Random.Range(0, _targets.Count);
            
            enemySpawner.SetTarget(_targets[targetIndex].transform);
            _targets.RemoveAt(targetIndex);
        }
    }
}
