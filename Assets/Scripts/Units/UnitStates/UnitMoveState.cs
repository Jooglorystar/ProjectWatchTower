using UnityEngine;

public class UnitMoveState : UnitBaseState
{
    public UnitMoveState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Move Start");
    }

    public override void MoveUpdate()
    {
        base.MoveUpdate();

        Move();
    }

    private void Move()
    {
        stateMachine.Unit.Movement.UnitMoveX();
    }
}
