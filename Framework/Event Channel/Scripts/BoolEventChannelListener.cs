using UnityEngine;
using UnityEngine.Events;

public class BoolEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private BoolEventChannelSO eventChannel;
    
    [Space]
    
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField]
    private UnityEvent<bool> onEventRaised;

    private void OnEnable()
    {
        if (this.eventChannel != null)
            this.eventChannel.OnEventRaised += Response;
    }

    private void OnDisable()
    {
        if (this.eventChannel != null)
            this.eventChannel.OnEventRaised -= Response;
    }

    private void Response(bool parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
