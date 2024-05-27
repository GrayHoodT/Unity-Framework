using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public abstract class EventReceivable<T> : MonoBehaviour
    {
        [SerializeField]
        protected EventableSO<T> eventSO;

        [Space(10), SerializeField]
        protected UnityEvent<object, T> OnRaise;

        protected virtual void OnEnable()
        {
            eventSO.Subscribe(this);
        }

        protected virtual void OnDisable()
        {
            eventSO.UnSubscribe(this);
        }

        public void Respond(object sender, T eventArgs)
        {
            OnRaise?.Invoke(sender, eventArgs);
        }
    }
}
