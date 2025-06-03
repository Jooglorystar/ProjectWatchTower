using UnityEngine;

public class Unit : MonoBehaviour
{
    private SpriteRenderer _sr;
    private UnitStateMachine _stateMachine;

    public UnitStateMachine StateMachine => _stateMachine;
    public UnitMovement Movement { get; private set; }


    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        Movement = GetComponent<UnitMovement>();

        _stateMachine = new UnitStateMachine(this);
    }

    private void FixedUpdate()
    {
        _stateMachine.MoveUpdate();
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
}
