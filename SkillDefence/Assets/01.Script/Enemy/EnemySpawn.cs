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
        //amount��ŭ enemy�� �Ҵ�� �� ����
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy,gameObject.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp,enemyCanvas.transform);
            //���� ����Ʈ�� ����
            EnemyManager.Instance.AddEnemyList(e);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
