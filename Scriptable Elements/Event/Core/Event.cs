using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GrayHoodT
{
    [Serializable]
    public abstract class Event<T> : EventBase
    {
        #region Fields

        [Space(10)]
        [SerializeField] protected UnityEvent<T> _onEventNotified;

        #endregion

        #region Methods

        public void Invoke(T obj)
        {
            _onEventNotified.Invoke(obj);
        }

        public void AddListener(UnityAction<T> call)
        {
            _onEventNotified.AddListener(call);
        }

        public void RemoveListener(UnityAction<T> call)
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

