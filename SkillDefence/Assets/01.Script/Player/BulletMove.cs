using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed;

    public int bullet_Damage = 20;

    public LayerMask whatIsEnemy;
    public bool bEnemyInSingRange;
    
    void Update()
    {
            transform.position += new Vector3(bulletSpeed, -0.2f, 0) * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            EnemyControl EC = col.gameObject.GetComponent<EnemyControl>();
            EC.IsHit(bullet_Damage);
            Destroy(gameObject);
        }

    }

}
