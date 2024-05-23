using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public interface IPoolable<T> where T : class
    {
        T Get();
        void Release(T item);
        void Clear();
    }
}
