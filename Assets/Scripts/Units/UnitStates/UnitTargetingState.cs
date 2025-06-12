using UnityEngine;

public class UnitTargetingState : UnitBaseState
{
    public UnitTargetingState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();

        stateMachine.Unit.Movement.SetSpeed(0);
    }

    public override void Update()
    {
        base.Update();

        TryAttack();
    }

    private float _timer = 0f;

    private void AttackTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= stateMachine.Unit.Data.UnitAttackDelay)
        {
            stateMachine.Unit.Attack();
            _timer = 0f;
        }
    }

    private bool TryAttack()
    {
        if(stateMachine.Unit.Target == null)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return false;
        }
        AttackTimer();

        return true;
    }
}