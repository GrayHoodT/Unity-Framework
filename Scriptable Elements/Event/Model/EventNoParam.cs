using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GrayHoodT
{
    [CreateAssetMenu(fileName = "EventNoParam", menuName = "Scriptable Objects/Event/NoParam")]
    public class EventNoParam : EventBase
    {
        #region Fields

        [Space(10)]
        [SerializeField] protected UnityEvent _onEventNotified;

        #endregion

        #region Methods

        public void Invoke()
        {
            _onEventNotified.Invoke();
        }

        public void AddListener(UnityAction call)
        {
            _onEventNotified.AddListener(call);
        }

        public void RemoveListener(UnityAction call)
        {
            _onEventNotified.RemoveListener(call);
        }

        public void RemoveAllListeners()
        {
            _onEventNotified.RemoveAllListeners();
        }

        #endregion
    }
}
