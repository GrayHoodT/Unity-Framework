using UnityEngine;
using UnityEngine.Events;

public class Vector3EventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private Vector3EventChannelSO eventChannel;

    [Space]

    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField]
    private UnityEvent<Vector3> onEventRaised;

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

    private void Response(Vector3 parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
