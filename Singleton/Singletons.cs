namespace GrayHoodT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _isDestroyed = false;
        private static object _lock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_isDestroyed)
                {
                    Utilities.LogError($"An <{typeof(T).Name}> instance of game object has already been destroyed. : Return Null!");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if(_instance == null)
                        {
                            Utilities.LogError($"Can't find <{typeof(T).Name}> game object. : Return Null!");
                            return null;
                        }
                    }

                    return _instance;
                }
            }
            private set => _instance = value;
        }

        protected virtual void Awake()
        {
            if (_instance != null)
                Destroy(gameObject);

            _instance = this as T;
        }

        protected virtual void OnApplicationQuit()
        {
            _isDestroyed = true;
        }

        protected virtual void OnDestroy()
        {
            _isDestroyed = true;
        }
    }

    public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}