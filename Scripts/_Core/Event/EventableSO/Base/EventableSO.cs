using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class EventableSO<T> : ScriptableObject
    {
        [SerializeField]
        protected List<EventReceivable<T>> receivers;

        public void Add(EventReceivable<T> item)
        {
            if (receivers.Contains(item) == true)
                return;

            receivers.Add(item);
        }
        public bool Remove(EventReceivable<T> item)
        {
            return receivers.Remove(item);
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
