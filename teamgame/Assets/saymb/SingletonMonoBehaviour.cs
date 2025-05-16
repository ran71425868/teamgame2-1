using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    private static T s_instance;
    public virtual void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this as T;
            Object.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (s_instance == this)
            s_instance = null;
    }
    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = (T)Object.FindFirstObjectByType(typeof(T));
                if (s_instance == null)
                    Create();
            }
            return s_instance;
        }
    }
    public static void Create()
    {
        s_instance = (T)Object.FindFirstObjectByType(typeof(T));
        if (s_instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            s_instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }
}
