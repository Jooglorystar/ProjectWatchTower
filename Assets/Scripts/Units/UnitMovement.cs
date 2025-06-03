using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_value">속도와 방향을 곱한 값</param>
    public void UnitMoveX()
    {
        _rb.linearVelocityX = _speed * _direction;
    }

    public void SetDirection(float p_value)
    {
        if (p_value == 0) _direction = 0f;

        _direction = p_value >= 0f ? 1f : -1f;
    }
}
