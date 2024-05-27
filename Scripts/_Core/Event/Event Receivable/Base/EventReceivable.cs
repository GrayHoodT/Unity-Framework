using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class EventReceivable : MonoBehaviour
    {
        [SerializeField]
        protected EventableSO eventSO;

        [Space(10), SerializeField]
        protected UnityEvent<object> OnRaise;

        protected virtual void OnEnable()
        {
            eventSO.Subscribe(this);
        }

        protected virtual void OnDisable()
        {
            eventSO.UnSubscribe(this);
        }

        public void Respond(object sender)
        {
            OnRaise?.Invoke(sender);
        }
    }
}
