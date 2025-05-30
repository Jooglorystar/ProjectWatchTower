using UnityEngine;

public class Unit : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.linearVelocityX = _speed * _direction;
    }

    public void SetDirection(float p_value)
    {
        if (p_value == 0) _direction = 0f;

        _direction = p_value >= 0f ? 1f : -1f;
    }

    public void SetColor(bool p_value)
    {
        if(p_value)
        {
            _sr.color = Color.blue;
        }
        else
        {
            _sr.color = Color.red;

        }
    }
}
