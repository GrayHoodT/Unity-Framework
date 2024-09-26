using UnityEngine;

public interface IStateMachine<T>
{
    T Owner { get; }
    void Initialize(T owner, IState initState);
    void ChangeState(IState nextState);
    void Update();
    void FixedUpdate();
}
