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

    }
}
