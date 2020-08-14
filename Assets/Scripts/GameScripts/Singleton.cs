using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if(_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.GetComponent<T>();
                obj.name = typeof(T).ToString();
            }
            return _instance;
        }
    }
}
