using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnTime;
    
    private Transform _target;
    private float _currentTime;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private IEnumerator Spawn()
    {
        var waitTime = new WaitForSeconds(_spawnTime);

        while (Application.isPlaying)
        {
            var enemy = Instantiate(_template, transform.position, Quaternion.identity);
            
            enemy.SetTarget(_target);
            yield return waitTime;
        }
    }
}
