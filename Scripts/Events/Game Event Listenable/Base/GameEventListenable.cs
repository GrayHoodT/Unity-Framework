using UnityEngine;
using UnityEngine.Events;

public class GameEventListenable : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventSO;

    [Space(10), SerializeField]
    private UnityEvent<object> OnRaise;

    private void OnEnable() => eventSO.Subscribe(this);
    private void OnDisable() => eventSO.UnSubscribe(this);

    public void Respond(object sender)
    {
        OnRaise?.Invoke(sender);
    }
}