using UnityEngine;

public class UnitTargetingState : UnitBaseState
{
    private float _timer = 0f;

    public UnitTargetingState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();

        stateMachine.Unit.Movement.SetSpeed(0);

        _timer = 0f;
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.Unit.Target != null)
        {
            AttackTimer();
        }
        else
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }


    private void AttackTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= stateMachine.Unit.Data.UnitAttackDelay)
        {
            if(stateMachine.Unit.DetectTarget())
            {
                stateMachine.Unit.Attack();
                _timer = 0f;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }
}