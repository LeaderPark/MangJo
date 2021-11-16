using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitClass
{
    public string name;
    public int star;
}

public class UnitSystem : MonoBehaviour
{
    unitClass unit = new unitClass();
    public List<GameObject> myunitList = new List<GameObject>();
    public List<string> unitList = new List<string>();
    #region 싱글톤
    private static UnitSystem instance;
    public static UnitSystem Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<UnitSystem>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("Singleton Class").AddComponent<UnitSystem>();
                    instance = newSingleton;
                }

            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    private void Awake()
    {
        var objs = FindObjectsOfType<UnitSystem>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    
}


