using UnityEngine;
using UnityEngine.Events;

public class VoidEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private VoidEventChannelSO eventChannel;
    
    [Space]
    
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] 
    private UnityEvent onEventRaised;


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

    private void Response()
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke();
    }
}
