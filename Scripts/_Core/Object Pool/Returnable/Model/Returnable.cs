using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class Returnable : MonoBehaviour, IReturnable<Returnable>
    {
        public IObjectPool<Returnable> Pool { get; set; }

        public virtual void ReturnToPool() => Pool.Release(this);
    }
}
