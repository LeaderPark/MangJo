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
        if(EnemyManager.Instance.stageClear){
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            EnemyControl EC = col.gameObject.GetComponent<EnemyControl>();
            EC.IsHit((int)GameManager.Instance.dic["bullet_Damage"]);
            Destroy(gameObject);
        }

    }
    IEnumerator BulletDes(){
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }

}
