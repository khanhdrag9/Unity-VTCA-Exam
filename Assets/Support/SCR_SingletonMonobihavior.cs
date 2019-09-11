using UnityEngine;

public class SCR_SingletonMonobihavior<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance{get; protected set;}
    protected virtual void Awake()
    {
        Instance = GetComponent<T>();
    }
}
