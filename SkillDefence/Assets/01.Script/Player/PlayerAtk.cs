using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{

    public float atkSpeed;

    public GameObject bulletPrefab;

    public Transform bulletParent;

    private float sightRange = 100;
    public LayerMask whatIsEnemy;
    public bool bEnemyInSingRange;

    bool isHit =false;
    private void Update()
    {
        bEnemyInSingRange = Physics2D.OverlapCircle(gameObject.transform.position, sightRange, whatIsEnemy);
        StartCoroutine(BulletSpawn());
    }

    IEnumerator BulletSpawn()
    {
        if(bEnemyInSingRange&&!isHit)
        {
            isHit = true;
            yield return new WaitForSeconds(atkSpeed);
            Instantiate(bulletPrefab, bulletParent);
            isHit = false;
        }
    }
}
