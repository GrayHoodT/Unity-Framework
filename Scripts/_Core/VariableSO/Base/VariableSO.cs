using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class VariableSO<T> : ScriptableObject
    {
        public T Value { get; set; }
    }
}
