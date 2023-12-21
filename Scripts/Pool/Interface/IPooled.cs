public interface IPooled
{
    void SetPool(Pooler pooler);
    void ReleaseToPool();
}