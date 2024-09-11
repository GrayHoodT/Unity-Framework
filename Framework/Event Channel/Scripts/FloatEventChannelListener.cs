using UnityEngine;
using UnityEngine.Events;

public class FloatEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private FloatEventChannelSO eventChannel;
    
    [Space]
    
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] 
    private UnityEvent<float> onEventRaised;

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

    private void Response(float parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
