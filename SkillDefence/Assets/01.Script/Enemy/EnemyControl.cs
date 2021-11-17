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

    public Animator anim;

    public int enemyNum;

    public ParticleSystem hitEffect;

    bool isDie;

    public AudioSource deadSound;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigi2d = GetComponent<Rigidbody2D>();
        enemy_MaxHp += GameManager.Instance.stage*25;
        enemy_NowHp = enemy_MaxHp;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        rampartPos = GameObject.Find("Rampart").GetComponent<Transform>();
        anim.Play($"Enemy{enemyNum}_Move");
    }

    void Update()
    {
        
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        enemy_bar.transform.position = gameObject.transform.position+ new Vector3(0,2,0);
        EnemyMove();
        if(GameManager.Instance.Rampart_NowHp <0){
            Destroy(enemy_bar.gameObject);
            Destroy(gameObject);
        }
    }
    public void IsHit(int damage)
    {
        enemy_NowHp -= damage;
        enemy_bar.value = enemy_NowHp / enemy_MaxHp;
        rigi2d.AddForce(transform.right * enemySpeed*1.5f);
        if(enemy_NowHp <= 0)
        {
            isDie = true;
            if(enemyNum == 2){
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0);
                Destroy(enemy_bar.gameObject,0.5f);
                Destroy(gameObject,0.5f);
            }
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            gameObject.GetComponent<Collider2D>().enabled =false;
            enemy_bar.gameObject.SetActive(false);
            anim.Play($"Enemy{enemyNum}_Die");
            EnemyManager.Instance.RemoveEnemyList(gameObject);
            EnemyManager.Instance.GetCoin(15);
            Destroy(enemy_bar.gameObject,1.5f);
            Destroy(gameObject,1.5f);
            deadSound.Play();
        }else{
            hitEffect.Play();
        }
    }

    private void EnemyMove()
    {
        bWallInSingRange = Physics2D.OverlapCircle(gameObject.transform.position, sightRange, whatIswall);
        if (!isATK&&!isDie)
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
        anim.Play($"Enemy{enemyNum}_Attak");
        GameManager.Instance.IsDamage(10);
        isATK = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }


}
