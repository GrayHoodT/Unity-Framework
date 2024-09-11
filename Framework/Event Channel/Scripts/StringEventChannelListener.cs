using UnityEngine;
using UnityEngine.Events;

public class StringEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private StringEventChannelSO eventChannel;

    [Space]
    
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] 
    private UnityEvent<string> onEventRaised;

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

    private void Response(string parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
