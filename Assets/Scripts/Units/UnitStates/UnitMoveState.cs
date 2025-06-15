using UnityEngine;

public class UnitMoveState : UnitBaseState
{
    public UnitMoveState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Move");
        stateMachine.Unit.Movement.SetSpeed(stateMachine.Unit.Data.UnitSpeed);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Unit.DetectTarget())
        {
            stateMachine.ChangeState(stateMachine.TargetingState);
        }
    }
}
