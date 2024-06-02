using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListenable<T> : MonoBehaviour
{
    [SerializeField]
    protected GameEvent<T> eventSO;

    [Space(10), SerializeField]
    protected UnityEvent<object, T> OnRaise;

    private void OnEnable() => eventSO.Subscribe(this);
    private void OnDisable() => eventSO.UnSubscribe(this);

    public void Respond(object sender, T eventArgs)
    {
        OnRaise?.Invoke(sender, eventArgs);
    }
}