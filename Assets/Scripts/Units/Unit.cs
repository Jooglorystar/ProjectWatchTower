using UnityEngine;

public class Unit : MonoBehaviour, IDamagable
{
    private SpriteRenderer _sr;
    private BoxCollider2D _collider;
    private UnitStateMachine _stateMachine;
    private UnitMovement _movement;
    [SerializeField] private UnitData _data;

    public UnitStateMachine StateMachine => _stateMachine;
    public UnitMovement Movement => _movement;
    public BoxCollider2D Collider => _collider;
    public UnitData Data => _data;

    private int curHealth;

    private Unit _target;

    public Unit Target => _target;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _movement = GetComponent<UnitMovement>();

        _stateMachine = new UnitStateMachine(this);

    }

    private void OnEnable()
    {
        UnitDataInit();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.MoveUpdate();
    }

    private void UnitDataInit()
    {
        Movement.SetSpeed(Data.UnitSpeed);
        curHealth = Data.UnitMaxHealth;
    }

    public void SetUnitData(UnitData p_data)
    {
        _data = p_data;
    }

    public void SetColor(bool p_value)
    {
        if (p_value)
        {
            _sr.color = Color.blue;
        }
        else
        {
            _sr.color = Color.red;
        }
    }

    public bool DetectTarget()
    {
        RaycastHit2D hit;

        Vector2 direction = Movement.Direction.normalized;
        Vector2 origin = (Vector2)transform.position + (direction * 0.5f);

        hit = Physics2D.Raycast(origin, direction, Data.UnitAttackRange, Data.TargetLayerMask);
        Debug.DrawRay(origin, direction * Data.UnitAttackRange, Color.red);
        if (hit)
        {
            _target = hit.collider.gameObject.GetComponent<Unit>();
            return true;
        }
        return false;
    }

    public void Attack()
    {
        if (_target == null) return;

        if (_target.Damaged(_data.UnitAttack))
        {
            _target = null;
        }
    }

    public bool Damaged(int p_value)
    {
        curHealth -= p_value;

        if (curHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        StageManager.Unit.Despawn(this);
    }
}
