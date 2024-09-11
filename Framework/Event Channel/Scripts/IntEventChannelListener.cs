using UnityEngine;
using UnityEngine.Events;

public class IntEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private IntEventChannelSO eventChannel;
    
    [Space]
    
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] 
    private UnityEvent<int> onEventRaised;

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

    private void Response(int parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
