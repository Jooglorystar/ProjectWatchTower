using UnityEngine;

public class UnitTargetingState : UnitBaseState
{
    public UnitTargetingState(UnitStateMachine p_stateMachine) : base(p_stateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();

        Debug.Log($"{stateMachine.Unit.name} Find Target");
        stateMachine.Unit.Movement.SetSpeed(0);
    }

    public override void Update()
    {
        base.Update();

        AttackTimer();

        if(stateMachine.Unit.Target == null)
        {
            stateMachine.ChangeState(stateMachine.MoveState);
        }
    }

    private float _attackInterval = 1f;
    private float _timer = 0f;

    private void AttackTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= _attackInterval)
        {
            Attack();
            _timer = 0f;
        }
    }

    private void Attack()
    {
        if(stateMachine.Unit.Target.Damaged(stateMachine.Unit.Data.UnitAttack))
        {
            stateMachine.Unit.SetTarget(null);
        }
    }
}