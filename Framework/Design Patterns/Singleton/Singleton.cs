using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name + " Auto-Generated");
                    instance = go.AddComponent<T>();
                }
            }

            return instance;
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
        DontDestroyOnLoad(gameObject);
    }
}
