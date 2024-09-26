using UnityEngine;

public interface IStateMachine
{
    void Initialize(IState initState);
    void ChangeState(IState nextState);
    void Update();
    void FixedUpdate();
}
