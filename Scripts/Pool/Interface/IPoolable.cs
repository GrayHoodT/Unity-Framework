public interface IPoolable
{
    void SetPool(Pooler pooler);
    void ReleaseToPool();
}