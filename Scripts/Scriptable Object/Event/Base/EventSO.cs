namespace GrayHoodT.Events
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class EventSO : EventBase
    {
        protected UnityAction<object> _onEventRaised;

        public event UnityAction<object> OnEventRaised
        {
            add => _onEventRaised += value;
            remove => _onEventRaised -= value;
        }

        public virtual void Invoke(object sender)
        {
            _onEventRaised?.Invoke(sender);
        }
    }

    public abstract class EventSO<T> : EventBase
    {
        protected UnityAction<object, T> _onEventRaised;

        public event UnityAction<object, T> OnEventRaised
        {
            add => _onEventRaised += value;
            remove => _onEventRaised -= value;
        }

        public virtual void Invoke(object sender, T eventArgs)
        {
            _onEventRaised?.Invoke(sender, eventArgs);
        }
    }
}

