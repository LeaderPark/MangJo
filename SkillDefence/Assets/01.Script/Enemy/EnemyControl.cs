using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public Transform rampartPos;
    [Header("���� ��Ÿ�")]
    public float sightRange = 1;
    [Header("���� �ӵ�")]
    public float atkSpeed;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    bool isATK = false;

    private float enemy_NowHp;
    public float enemy_MaxHp;

    public Slider enemy_bar;

    private void Start()
    {
        enemy_NowHp = enemy_MaxHp;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        rampartPos = GameObject.Find("Rampart").GetComponent<Transform>();
    }

    void Update()
    {
        enemy_bar.transform.position = gameObject.transform.position+ new Vector3(0,2,0);
        EnemyMove();
    }
    public void IsHit(int damage)
    {
        enemy_NowHp -= damage;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;

    }

    private void EnemyMove()
    {
        bWallInSingRange = Physics2D.OverlapCircle(gameObject.transform.position, sightRange, whatIswall);
        if (!isATK)
        {
            if (bWallInSingRange)
            {
                StartCoroutine(RampartATK());
                Debug.Log("����");
            }
            else
            {
                transform.position += new Vector3(-2f, 0, 0) * Time.deltaTime;
            }
        }
    }

    IEnumerator RampartATK()
    {
        isATK = true;
        GameManager.Instance.IsDamage(10);
        //���ϸ��̼� ����
        yield return new WaitForSeconds(atkSpeed);
        isATK = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
