using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public Transform rampartPos;
    public float sightRange = 1;
    public float atkSpeed;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    public float enemySpeed =2;

    bool isATK = false;

    public float enemy_NowHp;
    public float enemy_MaxHp;

    public Slider enemy_bar;

    private Rigidbody2D rigi2d;
    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        enemy_NowHp = enemy_MaxHp;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        rampartPos = GameObject.Find("Rampart").GetComponent<Transform>();
    }

    void Update()
    {
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        enemy_bar.transform.position = gameObject.transform.position+ new Vector3(0,2,0);
        EnemyMove();
        if(GameManager.Instance.Rampart_NowHp<0){
            Destroy(gameObject);
            Destroy(enemy_bar.gameObject);
        }
    }
    public void IsHit(int damage)
    {
        enemy_NowHp -= damage;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        rigi2d.AddForce(transform.right * enemySpeed*1.5f);
        if(enemy_NowHp <= 0)
        {
            EnemyManager.Instance.RemoveEnemyList(gameObject);
            GameManager.Instance.GetCoin(15);
            Destroy(enemy_bar.gameObject);
            Destroy(gameObject);
        }
    }

    private void EnemyMove()
    {
        bWallInSingRange = Physics2D.OverlapCircle(gameObject.transform.position, sightRange, whatIswall);
        if (!isATK)
        {
            if (bWallInSingRange)
            {
                StartCoroutine(RampartATK());
            }
            else
            {
                transform.position += new Vector3(-enemySpeed, 0, 0) * Time.deltaTime;
            }
        }
    }

    IEnumerator RampartATK()
    {
        isATK = true;
        yield return new WaitForSeconds(atkSpeed);
        GameManager.Instance.IsDamage(10);
        isATK = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
