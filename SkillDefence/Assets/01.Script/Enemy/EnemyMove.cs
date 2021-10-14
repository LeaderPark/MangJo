using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMove : MonoBehaviour
{
    public Transform rampartPos;

    public float sightRange = 1;
    public LayerMask whatIswall;
    public bool bWallInSingRange;

    bool isATK = false;
    private void Start()
    {
        rampartPos = GameObject.Find("Rampart").GetComponent<Transform>();
    }

    void Update()
    {
        bWallInSingRange = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(sightRange, sightRange), 90f);
        if (bWallInSingRange&&!isATK)
        {
            StartCoroutine(RampartATK());
            Debug.Log("공격");
        }
        else
        {
            //transform.position = transform.Translate(-2f, 0, 0);
            transform.position += new Vector3(-2f, 0, 0)*Time.deltaTime;
        }

    }

    IEnumerator RampartATK()
    {
        isATK = true;
        GameManager.Instance.Rampart_Hp -= 10;
        //에니매이션 실행
        yield return new WaitForSeconds(1f);
        isATK = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
