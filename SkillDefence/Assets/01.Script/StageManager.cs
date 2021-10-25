using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //?꿔꺂????????????먃????癲? ?癲ル슢캉????????녿뮝?????潁??GameManager.Instance.stage)
    //StartCoroutine(StageStart(?꿔꺂????욧퍗留ょ춯??강??? ????볥궖????,??????嚥▲굧????????鍮????곗뵯??);
    //?????먃??? ??????꿔꺂?????녿쫯???(EnemyManager.Instance.enemy_amount;) ?꿔꺂????욧퍗留ょ춯??강??? ????볥궖????(???嚥▲굧?????????鍮????곗뵯??????????β뼯爰귨㎘?????? ??潁??
    public Button nextStageBtn;
    public Canvas enemyCanvas;
    public GameObject spawnEnemy;

    private void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataTable");

        nextStageBtn.onClick.AddListener(() => 
        {

            EnemyManager.Instance.stageClear = false;
            for (var i = 0; i < data.Count; i++)
            {
                int inputStage = Convert.ToInt32(data[i]["Stage"]);
                int enemyCount = Convert.ToInt32(data[i]["Count"]);
                int spawnEnemy = Convert.ToInt32(data[i]["Monster"]);
                float spawnSec = (float)Convert.ToDouble(data[i]["Second"]);

                if (GameManager.Instance.stage == inputStage-1)
                {
                    StartCoroutine(StageStart(enemyCount,
                        EnemyManager.Instance.enemy_Spawn[spawnEnemy-1],
                        spawnSec));
                }
            }
            
        
        });
    }
    private void Update()
    {
        if (EnemyManager.Instance.stageClear)
        {
            nextStageBtn.gameObject.SetActive(true);
        }
        else
        {
            nextStageBtn.gameObject.SetActive(false);
        }
    }

    public IEnumerator StageStart(int amount, GameObject enemy, float sec)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy, spawnEnemy.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp, enemyCanvas.transform);
            EnemyManager.Instance.AddEnemyList(e);
            yield return new WaitForSeconds(sec);
        }
    }
}
