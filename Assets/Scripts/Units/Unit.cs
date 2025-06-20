using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour, IDamagable
{
    private SpriteRenderer _sr;
    private BoxCollider2D _collider;
    private UnitStateMachine _stateMachine;
    private UnitMovement _movement;
    [SerializeField] private UnitData _data;

    [SerializeField] private Image _healthBar;

    public UnitStateMachine StateMachine => _stateMachine;
    public UnitMovement Movement => _movement;
    public BoxCollider2D Collider => _collider;
    public UnitData Data => _data;

    private int _curHealth;

    public int CurHealth => _curHealth;

    private IDamagable _target;

    public IDamagable Target => _target;

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
        _curHealth = Data.UnitMaxHealth;
        _healthBar.fillAmount = _curHealth / Data.UnitMaxHealth;
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

        if (hit)
        {
            _target = StageManager.Instance.GetTargetFromDictionary(hit.collider.gameObject);
            return true;
        }
        _target = null;
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
        _curHealth -= p_value;
        _healthBar.fillAmount = (float)_curHealth / Data.UnitMaxHealth;
        if (_curHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        UnitManager.Instance.Despawn(this);
    }
}
