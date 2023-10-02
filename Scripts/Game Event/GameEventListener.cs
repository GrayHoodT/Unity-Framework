namespace GrayHoodT.Events
{
    using UnityEngine;
    using UnityEngine.Events;

    public sealed class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEventSO _gameEvent;

        [SerializeField] private UnityEvent<object, GameEventArgs> _response;

        private void OnEnable()
        {
            _gameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            _gameEvent.RemoveListener(this);
        }

        public void OnEventRaised(object sender, GameEventArgs args)
        {
            _response?.Invoke(sender, args);
        }
    }
}