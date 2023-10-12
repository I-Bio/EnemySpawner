using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;
    
    private Rigidbody2D _rigidbody;
    private Vector3 _movePosition;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector3 movePosition)
    {
        _movePosition = movePosition;
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _movePosition) >= _stopDistance)
        {
            Vector2 moveDirection = (_movePosition - transform.position).normalized;
            _rigidbody.velocity = moveDirection * _speed;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
