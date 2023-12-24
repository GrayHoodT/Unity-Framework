using UnityEngine;

namespace GrayHoodT.Pool
{
    public abstract class Poolable : MonoBehaviour, IPoolable<Poolable>
    {
        [field: SerializeField]
        public IPooler<Poolable> Pooler { get; protected set; }

        public void SetPooler(IPooler<Poolable> pooler)
        {
            Pooler = pooler;
        }

        public void ReturnToPooler()
        {
            Pooler.Return(this);
        }
    }
}