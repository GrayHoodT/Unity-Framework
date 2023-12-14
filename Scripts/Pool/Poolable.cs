using UnityEngine;

public abstract class Poolable : MonoBehaviour, IPoolable
{
    public Pooler pooler { get; protected set; }
    
    public abstract void SetPool(Pooler pooler);
    public abstract void ReleaseToPool();
}
