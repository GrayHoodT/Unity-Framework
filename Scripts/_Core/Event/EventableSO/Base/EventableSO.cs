using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [CreateAssetMenu(fileName = "Void Eventable SO", menuName = "Scriptable Objects/Event/Standard/Void", order = -1)]
    public class EventableSO : ScriptableObject
    {
        [Multiline(5)]
        [SerializeField]
        protected string desc;

        [SerializeField]
        protected List<EventReceivable> receivers;

        public void Subscribe(EventReceivable element)
        {
            if (receivers.Contains(element) == true)
                return;

            receivers.Add(element);
        }
        public bool UnSubscribe(EventReceivable element)
        {
            return receivers.Remove(element);
        }

        public void Raise(object sender)
        {
            for (var i = receivers.Count - 1; i >= 0; i--)
            {
                receivers[i].Respond(sender);
            }
        }
    }
}
