public class UnitStateMachine : StateMachine<UnitBaseState>
{
    private Unit _unit;

    public UnitIdleState IdleState { get; private set; }
    public UnitMoveState MoveState { get; private set; }
    public UnitTargetingState TargetingState { get; private set; }

    public Unit Unit => _unit;

    public UnitStateMachine(Unit unit)
    {
        _unit = unit;
        IdleState = new UnitIdleState(this);
        MoveState = new UnitMoveState(this);
        TargetingState = new UnitTargetingState(this);

        ChangeState(MoveState);
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
