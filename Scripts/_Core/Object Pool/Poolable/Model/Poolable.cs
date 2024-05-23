using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Core
{
    public class Poolable : MonoBehaviour, IPoolable<Returnable>
    {
        protected IObjectPool<Returnable> pool;

        [SerializeField]
        protected Returnable prefab;
        [SerializeField]
        protected bool collectionCheck;
        [SerializeField]
        protected int defaultCapacity;
        [SerializeField]
        protected int maxSize;

        private void Awake()
        {
            pool = new ObjectPool<Returnable>(Create, OnGot, OnReleased, OnDestroyed, collectionCheck, defaultCapacity, maxSize);
        }

        public virtual Returnable Get()
        {
            return pool.Get();
        }

        public virtual void Release(Returnable item)
        {
            pool.Release(item);
        }

        public virtual void Clear()
        {
            pool.Clear();
        }

        protected virtual Returnable Create()
        {
            return GameObject.Instantiate(prefab, transform);
        }

        protected virtual void OnGot(Returnable item)
        {
            item.gameObject.SetActive(true);
        }

        protected virtual void OnReleased(Returnable item)
        {
            item.gameObject.SetActive(false);
        }

        protected virtual void OnDestroyed(Returnable item)
        {
            Destroy(item.gameObject);
        }
    }
}
