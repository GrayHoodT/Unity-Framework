using System;
using UnityEngine;

namespace GrayHoodT
{
    [Serializable]
    public abstract class Variable<T> : VariableBase
    {
        #region Fields

        [SerializeField] protected T _value;

        #endregion

        #region Properties

        public override Type GetGenericType => typeof(T);

        public T PreviousValue { get; private set; }
        
        public virtual T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                    return;

                PreviousValue = _value;
                _value = value;
            }
        }

        #endregion
    }
}

