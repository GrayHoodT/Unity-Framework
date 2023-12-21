using UnityEngine;

public interface IPooler
{
    Pooled Spawn(Vector3 position = default, Vector3 rotation = default, Vector3 localScale = default);
    void Release(Pooled pooledObject);
    void ReleaseAll();
}