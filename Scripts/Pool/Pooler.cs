using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour, IPooler
{
    [field: Header("Configs")]
    [field: SerializeField]
    public Pooled Prefab { get; protected set; }
    [field: SerializeField]
    public int DefaultCapacity { get; protected set; }
    [field: SerializeField]
    public int MaxSize { get; protected set; }

    public IObjectPool<Pooled> ObjectPool { get; protected set; }

    [field: Space(5)]
    [field: Header("Actived Objects")]
    [field: SerializeField]
    public List<Pooled> ActivedObjectList { get; protected set; }

    #region Events

    protected Action<Pooled> created;
    protected Action<Pooled> got;
    protected Action<Pooled> released;
    protected Action<Pooled> destroyed;

    public event Action<Pooled> Created { add => created += value; remove => created -= value; }
    public event Action<Pooled> Got { add => got += value; remove => created -= value; }
    public event Action<Pooled> Released { add => released += value; remove => created -= value; }
    public event Action<Pooled> Destroyed { add => destroyed += value; remove => created -= value; }

    #endregion

    protected virtual void Awake()
    {
        ObjectPool = new ObjectPool<Pooled>(CreatePooledObject, OnPooledObjectGot, OnPooledObjectReleased, OnPooledObjectDestroyed, true, DefaultCapacity, MaxSize);
        ActivedObjectList = new List<Pooled>();
    }

    public virtual Pooled Spawn(Vector3 position = default, Vector3 rotation = default, Vector3 localScale = default)
    {
        Pooled pooledObject = ObjectPool.Get();
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = Quaternion.Euler(rotation);
        pooledObject.transform.localScale = localScale;
        pooledObject.gameObject.SetActive(true);

        return pooledObject;
    }

    public virtual void Release(Pooled pooledObject)
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

    protected virtual Pooled CreatePooledObject()
    {
        Pooled createdObject = Instantiate(Prefab);
        createdObject.SetPool(this);
        created?.Invoke(createdObject);

        return createdObject;
    }

    protected virtual void OnPooledObjectGot(Pooled pooledObject)
    {
        ActivedObjectList.Add(pooledObject);
        got?.Invoke(pooledObject);
    }

    protected virtual void OnPooledObjectReleased(Pooled pooledObject)
    {
        ActivedObjectList.Remove(pooledObject);
        released?.Invoke(pooledObject);
    }

    protected virtual void OnPooledObjectDestroyed(Pooled pooledObject)
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
