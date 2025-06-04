using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private Vector2 _direction = new Vector2(0, 0);


    public Vector2 Direction => _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        if (p_value == 0) _direction.x = 0f;

        _direction.x = p_value >= 0f ? 1f : -1f;

        if (_direction.x >= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
