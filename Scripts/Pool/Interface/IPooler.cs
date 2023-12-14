using UnityEngine;

public interface IPooler
{
    Poolable SpawnPooledObject(Vector3 position = default, Vector3 rotation = default, Vector3 localScale = default);
    void Release(Poolable pooledObject);
    void Clear();
}