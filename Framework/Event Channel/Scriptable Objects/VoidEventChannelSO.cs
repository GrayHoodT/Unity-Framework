using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Void Event Channel SO", menuName = "Scriptable Objects/Events/Void")]
public class VoidEventChannelSO : DescriptionSO
{
    protected UnityAction onEventRaised;

    public event UnityAction OnEventRaised
    {
        add => this.onEventRaised += value;
        remove => this.onEventRaised -= value;
    }

    public void RaiseEvent()
    {
        if (this.onEventRaised != null)
            return;

        this.onEventRaised.Invoke();
    }
}
