using UnityEngine;

namespace Managers
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }

    }

    public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null) { DestroyImmediate(gameObject); return; }
            
            if (transform.parent != null) transform.parent = null;

            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }
}