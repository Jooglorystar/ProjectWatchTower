using UnityEngine;
using static UnityEngine.UI.Image;

public abstract class UnitBaseState : IState
{
    protected UnitStateMachine stateMachine;

    public UnitBaseState(UnitStateMachine p_stateMachine)
    {
        stateMachine = p_stateMachine;
    }

    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void Update()
    {
    }

    public virtual void MoveUpdate()
    {
        Move();
    }

    private void Move()
    {
        stateMachine.Unit.Movement.UnitMoveX();
    }

    protected bool DetectEnemyUnit(out Unit p_unit)
    {
        RaycastHit2D hit;

        Vector2 direction = stateMachine.Unit.Movement.Direction.normalized;
        Vector2 origin = (Vector2)stateMachine.Unit.transform.position + (direction * 0.5f);

        float detectRange = 1f;

        hit = Physics2D.Raycast(origin, direction, detectRange, stateMachine.Unit.Data.TargetLayerMask);

        if (hit)
        {
            Debug.Log($"{stateMachine.Unit.name} Detect {hit.collider.gameObject.name}");
            Debug.DrawRay(origin, direction * detectRange, Color.blue);
            p_unit = hit.collider.gameObject.GetComponent<Unit>();
            return true;
        }
        Debug.DrawRay(origin, direction * detectRange, Color.red);
        p_unit = null;
        return false;
    }
}
