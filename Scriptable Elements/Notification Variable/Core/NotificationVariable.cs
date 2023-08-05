using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrayHoodT
{
    [Serializable]
    public class NotificationVariable<T> : NotificationVariableBase
    {
        #region

        [SerializeField] protected Variable<T> _variable;
        [SerializeField] protected Event<T> _onValueChanged;

        #endregion

        #region Properties

        public override Type GetGenericType => typeof(T);

        public virtual T Value
        {
            get => _variable.Value;
            set
            {
                if (Equals(_variable.Value, value))
                    return;

                _variable.Value = value;
                _onValueChanged?.Invoke(value);
            }
        }

        public virtual Event<T> OnValueChanged => _onValueChanged;

        #endregion

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if(_variable == null || _onValueChanged == null)
                return;

            if (Equals(_variable.Value, _variable.PreviousValue))
                return;

            _onValueChanged?.Invoke(Value);
        }
#endif
    }
}
