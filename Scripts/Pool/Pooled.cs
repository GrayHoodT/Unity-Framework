using UnityEngine;

public abstract class Pooled : MonoBehaviour, IPooled
{
    public Pooler pooler { get; protected set; }
    
    public abstract void SetPool(Pooler pooler);
    public abstract void ReleaseToPool();
}
