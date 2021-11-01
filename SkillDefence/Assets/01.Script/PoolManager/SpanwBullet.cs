using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwBullet : MonoBehaviour
{
 public string bulletName = "Bullet";
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
 
    void Shoot()
    {
        // ObjectPool.Instance.PopFromPool(bulletName);
        GameObject bullet = ObjectPool.Instance.PopFromPool(bulletName);
        bullet.transform.position = transform.position + transform.up;
        bullet.SetActive(true);
    }
}
