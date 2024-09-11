using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [SerializeField]
    private GameObjectEventChannelSO eventChannel;

    [Space]

    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField]
    private UnityEvent<GameObject> onEventRaised;

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

    private void Response(GameObject parameter)
    {
        if (this.onEventRaised != null)
            this.onEventRaised.Invoke(parameter);
    }
}
