using UnityEngine;

public abstract class GenericState<T> : DescriptionSO, IState<T>
{
    [SerializeField]
    protected T owner;

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();

    public void SetOwner(T owner) => this.owner = owner;
}
