using UnityEngine;

public class Unit : MonoBehaviour
{
    private Rigidbody2D _rb;


    [SerializeField]private float _speed = 3f;
    private float _direction = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rb.linearVelocityX = _speed * _direction;
    }

    public void SetDirection(float p_value)
    {
        if(p_value == 0) _direction = 0f;

        _direction = p_value >= 0f ? 1f : -1f;
    }
}
