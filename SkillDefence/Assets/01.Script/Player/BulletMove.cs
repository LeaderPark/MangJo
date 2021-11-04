using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed;


    public LayerMask whatIsEnemy;
    public bool bEnemyInSingRange;
    private void Start() {
        StartCoroutine(BulletDes());
    }
    void Update()
    {
            transform.position += new Vector3(bulletSpeed, -0.2f, 0) * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            EnemyControl EC = col.gameObject.GetComponent<EnemyControl>();
            EC.IsHit(GameManager.Instance.bullet_Damage);
            Destroy(gameObject);
        }

    }
    IEnumerator BulletDes(){
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

}
