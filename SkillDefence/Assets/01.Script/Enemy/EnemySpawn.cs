using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public Button stageBtn;
    private int nowStage;
    public Canvas enemyCanvas;
    public void Start()
    {
        if(GameManager.Instance.stage != null)
        {
            nowStage = GameManager.Instance.stage;
        }

        stageBtn.onClick.AddListener(() =>
        {
            StartCoroutine(StageStart(
                EnemyManager.Instance.enemy_amount[nowStage]
                , EnemyManager.Instance.enemy_Spawn[0])
                );
        });

    }

    IEnumerator StageStart(int amount,GameObject enemy)
    {
        //amount만큼 enemy에 할당된 적 생성
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy,gameObject.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp,enemyCanvas.transform);
            //적을 리스트에 저장
            EnemyManager.Instance.AddEnemyList(e);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
