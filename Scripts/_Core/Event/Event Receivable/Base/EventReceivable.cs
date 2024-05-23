using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public abstract class EventReceivable<T> : MonoBehaviour
    {
        [SerializeField]
        protected EventableSO<T> eventSO;

        [Space(10), SerializeField]
        protected UnityEvent<object, T> OnRaised;

        protected virtual void OnEnable()
        {
            eventSO.Add(this);
        }

        protected virtual void OnDisable()
        {
            eventSO.Remove(this);
        }

        public void Respond(object sender, T eventArgs)
        {
            OnRaised?.Invoke(sender, eventArgs);
        }
    }
}
