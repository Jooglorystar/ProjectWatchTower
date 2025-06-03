public class UnitStateMachine : StateMachine<UnitBaseState>
{
    private Unit _unit;

    private UnitIdleState _idleState;
    private UnitMoveState _moveState;

    public Unit Unit => _unit;

    public UnitStateMachine(Unit unit)
    {
        _unit = unit;
        _idleState = new UnitIdleState(this);
        _moveState = new UnitMoveState(this);

        ChangeState(_moveState);
    }

    public void Update()
    {
        currentState.Update();
    }

    public void MoveUpdate()
    {
        currentState.MoveUpdate();
    }
}
