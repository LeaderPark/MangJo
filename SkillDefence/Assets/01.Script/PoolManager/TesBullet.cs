using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TesBullet : MonoBehaviour
{
    public string poolItemName = "Bullet";
 
    private void Start() {
        StartCoroutine(DisBullet());
    }  
    IEnumerator DisBullet(){
        yield return new WaitForSeconds(1f);   
        ObjectPool.Instance.PushToPool(poolItemName, gameObject);

    }
}
