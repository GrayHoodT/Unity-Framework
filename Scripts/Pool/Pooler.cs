using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour, IPooler
{
    [field: Header("Configs")]
    [field: SerializeField]
    public Poolable Prefab { get; protected set; }
    [field: SerializeField]
    public int DefaultCapacity { get; protected set; }
    [field: SerializeField]
    public int MaxSize { get; protected set; }

    public IObjectPool<Poolable> ObjectPool { get; protected set; }

    [field: Space(5)]
    [field: Header("Actived Objects")]
    [field: SerializeField]
    public List<Poolable> ActivedObjectList { get; protected set; }

    #region Events

    protected Action<Poolable> created;
    protected Action<Poolable> got;
    protected Action<Poolable> released;
    protected Action<Poolable> destroyed;

    public event Action<Poolable> Created { add => created += value; remove => created -= value; }
    public event Action<Poolable> Got { add => got += value; remove => created -= value; }
    public event Action<Poolable> Released { add => released += value; remove => created -= value; }
    public event Action<Poolable> Destroyed { add => destroyed += value; remove => created -= value; }

    #endregion

    protected virtual void Awake()
    {
        ObjectPool = new ObjectPool<Poolable>(CreatePooledObject, OnPooledObjectGot, OnPooledObjectReleased, OnPooledObjectDestroyed, true, DefaultCapacity, MaxSize);
        ActivedObjectList = new List<Poolable>();
    }

    public virtual Poolable Spawn(Vector3 position = default, Vector3 rotation = default, Vector3 localScale = default)
    {
        Poolable pooledObject = ObjectPool.Get();
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = Quaternion.Euler(rotation);
        pooledObject.transform.localScale = localScale;
        pooledObject.gameObject.SetActive(true);

        return pooledObject;
    }

    public virtual void Release(Poolable pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        ObjectPool.Release(pooledObject);
    }

    public virtual void ReleaseAll()
    {
        for(var i = ActivedObjectList.Count - 1; i >= 0; i--)
        {
            var pooledObject = ActivedObjectList[i];
            Release(pooledObject);
        }
    }

    #region Object Pool Callbacks

    protected virtual Poolable CreatePooledObject()
    {
        Poolable createdObject = Instantiate(Prefab);
        createdObject.SetPool(this);
        created?.Invoke(createdObject);

        return createdObject;
    }

    protected virtual void OnPooledObjectGot(Poolable pooledObject)
    {
        ActivedObjectList.Add(pooledObject);
        got?.Invoke(pooledObject);
    }

    protected virtual void OnPooledObjectReleased(Poolable pooledObject)
    {
        ActivedObjectList.Remove(pooledObject);
        released?.Invoke(pooledObject);
    }

    protected virtual void OnPooledObjectDestroyed(Poolable pooledObject)
    {
        Destroy(pooledObject.gameObject);
        destroyed?.Invoke(pooledObject);
    }

    #endregion

    #region Factory Method Pattern

    public static Pooler CreatePooler(Pooler poolerPerfab, Vector3 position = default, Quaternion rotation = default, Transform parent = default)
    {
        Pooler pooler = Instantiate<Pooler>(poolerPerfab, position, rotation, parent);
        return pooler;
    }

    #endregion
}
