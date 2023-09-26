namespace GrayHoodT.Events
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Game Event SO", menuName = "Scriptable Object/Game Event")]
    public sealed class GameEventSO : ScriptableObject
    {
        [SerializeField] private List<GameEventListener> _listeners = new List<GameEventListener>();

        public IReadOnlyList<GameEventListener> Listeners => _listeners;

        public void AddListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Raise(object sender, GameEventArgs args)
        {
            foreach (GameEventListener listener in _listeners)
            {
                listener.OnEventRaised(sender, args);
            }
        }
    }
}

