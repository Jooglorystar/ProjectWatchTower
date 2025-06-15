using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private Vector2 _direction = new Vector2(0, 0);


    public Vector2 Direction => _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void UnitMoveX()
    {
        _rb.linearVelocityX = _speed * _direction.x;
    }

    public void SetSpeed(float p_value)
    {
        _speed = p_value;
    }

    public void SetDirection(float p_value)
    {
        _direction.x = p_value >= 0f ? 1f : -1f;

        if (_direction.x >= 0)
        {
            _sr.flipX = false;
        }
        else
        {
            _sr.flipX = true;
        }
    }
}
