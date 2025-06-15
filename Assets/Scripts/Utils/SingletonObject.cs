using UnityEngine;

public abstract class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance 
    {  
        get 
        {
            if(_instance == null)
            {
                GameObject go = new GameObject(typeof(T).Name);
                go.AddComponent<T>();
            }
            return _instance; 
        } 
    }

    protected virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
