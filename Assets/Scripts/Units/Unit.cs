using UnityEngine;

[System.Serializable]
public class UnitData
{
    public float UnitSpeed;
    public LayerMask TargetLayerMask;
}

public class Unit : MonoBehaviour
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
    public string TargetTag;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _movement = GetComponent<UnitMovement>();

        _stateMachine = new UnitStateMachine(this);

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
    }

    public void SetColor(bool p_value)
    {
        if (p_value)
        {
            _sr.color = Color.blue;
            Data.TargetLayerMask = 1 << LayerMask.NameToLayer("Enemy");
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else
        {
            _sr.color = Color.red;
            Data.TargetLayerMask = 1 << LayerMask.NameToLayer("Player");
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
