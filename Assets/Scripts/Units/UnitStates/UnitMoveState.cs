using UnityEngine;

public class UnitMoveState : UnitBaseState
{
    public UnitMoveState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log($"{stateMachine.Unit.name} Move Start");
        stateMachine.Unit.Movement.SetSpeed(stateMachine.Unit.Data.UnitSpeed);
    }

    public override void Update()
    {
        base.Update();

        if (DetectEnemyUnit())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
