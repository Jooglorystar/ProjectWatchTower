using UnityEngine;

public class UnitIdleState : UnitBaseState
{
    public UnitIdleState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Idle");
        stateMachine.Unit.Movement.SetSpeed(0);
    }

    public override void Update()
    {
        base.Update();

        if(!StageManager.IsGameEnd())
        {
            if (stateMachine.Unit.DetectTarget())
            {
                stateMachine.ChangeState(stateMachine.TargetingState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
        }
    }
}
