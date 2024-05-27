using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class EventableSO<T> : ScriptableObject
    {
        [Multiline(5)]
        [SerializeField]
        protected string desc;

        [SerializeField]
        protected List<EventReceivable<T>> receivers;

        public void Subscribe(EventReceivable<T> element)
        {
            if (receivers.Contains(element) == true)
                return;

            receivers.Add(element);
        }
        public bool UnSubscribe(EventReceivable<T> element)
        {
            return receivers.Remove(element);
        }

        public void Raise(object sender, T eventArgs)
        {
            for(var i = receivers.Count - 1; i >= 0; i--)
            {
                receivers[i].Respond(sender, eventArgs);
            }
        }
    }
}
