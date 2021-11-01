using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public List<PooledObject> objectPool = new List<PooledObject>();

    void Awake() {
        for(int ix = 0; ix < objectPool.Count; ++ix){
            objectPool[ix].Initialize(transform);
        }    
    }

    //부모를 찾아 객체를 넣는 함수
    public bool PushPool(string itemName, GameObject item, Transform parent = null) {
        PooledObject pool = GetPoolItem(itemName);
        if(pool == null)
            return false;

        pool.PushToPool(item,parent == null ? transform : parent);
        return true;
    }

    public GameObject PopFromPool(string itemName,GameObject item,Transform parent = null){
        PooledObject pool = GetPoolItem(itemName);
        if(pool == null)
            return null;

            return pool.PopFromPool(parent);
    }

    PooledObject GetPoolItem(string itemName) {
        for(int ix = 0; ix < objectPool.Count; ++ix){
            if(objectPool[ix].poolItemName.Equals(itemName))
                return objectPool[ix];
        }
        Debug.LogWarning("There's no matched pool list.");
        return null;
    }
}