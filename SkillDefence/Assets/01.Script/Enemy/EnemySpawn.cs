using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public Button stageBtn;
    private int nowStage;
    public Canvas enemyCanvas;
    public PlayerAtk PA;
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

        PA = GetComponent<PlayerAtk>();
    }

    IEnumerator StageStart(int amount,GameObject enemy)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy,gameObject.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp,enemyCanvas.transform);
            EnemyManager.Instance.left_enemy++;
            yield return new WaitForSeconds(0.5f);
        }
        PA.atkPlayer();
    }

}
