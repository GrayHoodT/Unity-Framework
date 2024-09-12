using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Void Event Channel SO", menuName = "Scriptable Objects/Events/Void")]
public class VoidEventChannelSO : DescriptionSO
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        if (this.OnEventRaised != null)
            return;

        this.OnEventRaised.Invoke();
    }
}
