using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
        
        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if (transform.parent != null)
                {
                    transform.parent = null;
                }
                Init();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected abstract void Init();
    }
}


