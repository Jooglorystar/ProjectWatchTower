using UnityEngine;

public class UnitIdleState : UnitBaseState
{
    public UnitIdleState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Idle Start");
    }
}
