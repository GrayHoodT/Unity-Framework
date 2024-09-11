public interface IState<T>
{
    void OnEnter();
    void OnExit();
    void OnUpdate();

    void SetOwner(T owner);
}