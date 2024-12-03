using System;
using UnityEngine;

public class Singleton<T> : IDisposable where T : class, new()
{
    protected static T instance;
    protected static readonly object @lock = new();

    public static bool HasInstance => Singleton<T>.instance != null;
    public static T TryGetInstance() => HasInstance ? Singleton<T>.instance : null;
    public static T Instance
    {
        get
        {
            lock (Singleton<T>.@lock)
            {
                if (Singleton<T>.instance == null)
                    Singleton<T>.Create();

                return Singleton<T>.instance;
            }
        }
        protected set => Singleton<T>.instance = value;
    }

    public static void Create()
    {
        if ((object)Singleton<T>.instance != null)
            return;

        Singleton<T>.instance = new T();
    }

    /// <summary>
    /// 'Dispose' �Լ��� �������Ͽ� ����� ���, 'base.Dispose()' ȣ���� �ݵ�� �ʿ���.
    /// </summary>
    public virtual void Dispose()
    {
        if (Singleton<T>.instance != null && Singleton<T>.instance != this as T)
            return;

        Singleton<T>.instance = null;
    }
}

public class SingletonWithMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    protected static readonly object @lock = new();

    public static bool HasInstance => SingletonWithMonoBehaviour<T>.instance != null;
    public static T TryGetInstance() => HasInstance ? SingletonWithMonoBehaviour<T>.instance : null;

    public static T Instance
    {
        get
        {
            lock (SingletonWithMonoBehaviour<T>.@lock)
            {
                if (SingletonWithMonoBehaviour<T>.instance == null)
                    SingletonWithMonoBehaviour<T>.instance = FindObjectOfType<T>();

                if (SingletonWithMonoBehaviour<T>.instance == null)
                    Create();

                return SingletonWithMonoBehaviour<T>.instance;
            }
        }
    }

    public static void Create()
    {
        if ((object)SingletonWithMonoBehaviour<T>.instance != null)
            return;

        GameObject go = new GameObject(typeof(T).Name);
        go.hideFlags = HideFlags.DontSave;
        go.AddComponent<T>();
    }

    /// <summary>
    /// 'Awake' �̺�Ʈ �Լ��� �������Ͽ� ����� ���, 'base.Awake()' ȣ���� �ݵ�� �ʿ���.
    /// </summary>
    protected virtual void Awake()
    {
        if (Application.isPlaying == false)
            return;

        if (SingletonWithMonoBehaviour<T>.instance != null && SingletonWithMonoBehaviour<T>.instance != this)
        {
            Destroy(gameObject);
            return;
        }

        SingletonWithMonoBehaviour<T>.instance = this as T;
    }

    /// <summary>
    /// 'OnDestroy' �̺�Ʈ �Լ��� �������Ͽ� ����� ���, 'base.OnDestroy()' ȣ���� �ݵ�� �ʿ���.
    /// </summary>
    protected virtual void OnDestroy() 
    {
        if (SingletonWithMonoBehaviour<T>.instance != null || SingletonWithMonoBehaviour<T>.instance != this)
            return;

        SingletonWithMonoBehaviour<T>.instance = null;
    }
}