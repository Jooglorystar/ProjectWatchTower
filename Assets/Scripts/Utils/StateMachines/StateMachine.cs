using UnityEngine;

public abstract class StateMachine<T> where T : IState
{
    protected T currentState;

    public T CurrentState => currentState;


    public void ChangeState(T p_newState)
    {
        currentState?.ExitState();
        currentState = p_newState;
        currentState.EnterState();
    }
}
