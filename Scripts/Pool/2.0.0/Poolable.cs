using UnityEngine;
using UnityEngine.Pool;

namespace GrayHoodT.Pool
{
    public abstract class Poolable : MonoBehaviour, IPoolable<Poolable>
    {
        [field: SerializeField]
        public IObjectPool<Poolable> Pool { get; set; }

        public void ReturnToPool() => Pool.Release(this);
    }
}