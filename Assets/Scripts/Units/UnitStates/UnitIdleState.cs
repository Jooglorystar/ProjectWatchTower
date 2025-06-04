using UnityEngine;

public class UnitIdleState : UnitBaseState
{
    public UnitIdleState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log($"{stateMachine.Unit.name} Idle Start");
        stateMachine.Unit.Movement.SetSpeed(0);
    }

    public override void Update()
    {
        base.Update();

        if (!DetectEnemyUnit())
        {
            stateMachine.ChangeState(stateMachine.MoveState);
        }
    }
}