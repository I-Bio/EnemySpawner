using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Type _type;
    
    private Transform _target;
    
    private enum Type
    {
        Standard,
        Fast,
        Slow,
        Big,
        Small,
    }

    private void Start()
    {
        SetTypeFeatures();
    }

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.position =  Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void SetTypeFeatures()
    {
        switch (_type)
        {
            case Type.Fast:
                float speedIncrease = 2f;
                _speed *= speedIncrease;
                break;
            
            case Type.Slow:
                float speedDecrease = 0.5f;
                _speed *= speedDecrease;
                break;
            
            case Type.Big:
                float sizeIncrease = 2f;
                transform.localScale = new Vector3(transform.localScale.x * sizeIncrease, transform.localScale.y * sizeIncrease, 0);
                break;
            
            case Type.Small:
                float sizeDecrease = 0.5f;
                transform.localScale = new Vector3(transform.localScale.x * sizeDecrease, transform.localScale.y * sizeDecrease, 0);
                break;
        }
    }
}
