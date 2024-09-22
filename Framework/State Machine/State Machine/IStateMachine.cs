public interface IStateMachine<T>
{
    void ChangeState(T newState);
    void UpdateState();
}
