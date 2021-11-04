using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Button nextStageBtn;
    public Button reStart;
    public CanvasGroup stageCanves;

    public Canvas enemyCanvas;
    public GameObject spawnEnemy;
    private void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataTable");

        StageStart(data);
        stageCanves.alpha = 0;
        nextStageBtn.onClick.AddListener(() =>
        {
            StageStart(data);
        });

        reStart.onClick.AddListener(() =>
        {
        if (GameManager.Instance.stage > 0) GameManager.Instance.stage--;
            StageStart(data);
        });
    }

    private void Update()
    {
        if (EnemyManager.Instance.stageClear)
        {
            DOTween.To(() => stageCanves.alpha, x => stageCanves.alpha = x, 1, 0.5f);
        }
        else
        {
            DOTween.To(() => stageCanves.alpha, x => stageCanves.alpha = x, 0, 0.5f);
        }
    }

    private void StageStart(List<Dictionary<string, object>> data)
    {
        EnemyManager.Instance.stageClear = false;
        for (var i = 0; i < data.Count; i++)
        {
            int inputStage = Convert.ToInt32(data[i]["Stage"]);
            int enemyCount = Convert.ToInt32(data[i]["Count"]);
            int spawnEnemy = Convert.ToInt32(data[i]["Monster"]);
            float spawnSec = (float)Convert.ToDouble(data[i]["Second"]);
            if (GameManager.Instance.stage == inputStage - 1)
            {
                StartCoroutine(StageStart(enemyCount,
                    EnemyManager.Instance.enemy_Spawn[spawnEnemy - 1],
                    spawnSec));
            }
        }
    }

    public IEnumerator StageStart(int amount, GameObject enemy, float sec)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(sec);
            GameObject e = Instantiate(enemy, spawnEnemy.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp, enemyCanvas.transform);
            EnemyManager.Instance.AddEnemyList(e);

        }
    }
}
