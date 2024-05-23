using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public interface IReturnable<T> where T : class
    {
        IObjectPool<T> Pool { get; set; }
        void ReturnToPool();
    }
}
