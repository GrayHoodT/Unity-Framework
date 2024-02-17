using UnityEngine.Pool;

namespace GrayHoodT.Pool
{
    public interface IPoolable<T> where T : class
    {
        IObjectPool<T> Pool { get; set; }
        void ReturnToPool();
    }
}