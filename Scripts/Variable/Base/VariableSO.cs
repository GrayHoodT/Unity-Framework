namespace GrayHoodT.Variables
{
    using System;
    using UnityEngine;

    public abstract class VariableSO<T> : ScriptableObject
    {
        [SerializeField] protected T _value;

        protected Action<T> _valueChanged;
        
        public virtual T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                    return;

                _value = value;
                _valueChanged?.Invoke(_value);
            }
        }

        public event Action<T> ValueChanged
        {
            add => _valueChanged += value;
            remove => _valueChanged -= value;
        }
    }
}

