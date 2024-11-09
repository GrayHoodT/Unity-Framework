using System;
using UnityEngine;

public class Singleton<T> : IDisposable where T : class, new()
{
    protected static T instance;
    protected static readonly object @lock = new();

    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;
    public static T Instance
    {
        get
        {
            lock (@lock)
            {
                if (instance == null)
                    instance = new T();

                return instance;
            }
        }
    }

    public virtual void Dispose()
    {
        if (instance != null && instance != this)
            return;

        instance = null;
    }
}

public class SingletonWithMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    protected static readonly object @lock = new();

    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;

    public static T Instance
    {
        get
        {
            lock (@lock)
            {
                if (instance == null)
                    instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    instance = go.AddComponent<T>();
                }

                return instance;
            }
        }
    }

    /// <summary>
    /// 'Awake' �̺�Ʈ �Լ��� �������Ͽ� ����� ���, 'base.Awake()' ȣ���� �ݵ�� �ʿ���.
    /// </summary>
    protected virtual void Awake()
    {
        if (Application.isPlaying == false)
            return;

        if (instance != null || instance != this)
            Destroy(gameObject);

        instance = this as T;
    }

    protected virtual void OnDestroy() 
    {
        if (instance != null || instance != this)
            return;

        instance = null;
    }
}