using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    public Button nextStageBtn;
    public Button reStart;
    public Button menuBtn;
    public CanvasGroup stageCanves;

    public Button shopBtn;

    public Canvas enemyCanvas;
    public GameObject spawnEnemy;

    public GameObject shop;

    public GameObject inGame;

    public AudioSource inGameSound;

    public AudioSource shopSound;
    private void Start()
    {
        inGameSound.Play();
        shop.SetActive(false);
        inGame.SetActive(true);
        List<Dictionary<string, object>> data = CSVReader.Read("DataTable");

        StageStart(data);
        stageCanves.gameObject.SetActive(false);
        stageCanves.alpha = 0;
        nextStageBtn.onClick.AddListener(() =>
        {
            if(!GameManager.Instance.stageFail){
                 GameManager.Instance.stage++;
            }else{
                GameManager.Instance.stageFail = false;
            }
            GameManager.Instance.Reset();
            StageStart(data);
        });

        menuBtn.onClick.AddListener(()=>{
            SceneManager.LoadScene(0);
        });

        reStart.onClick.AddListener(() =>
        {
            GameManager.Instance.Reset();
            StageStart(data);
        });

        shopBtn.onClick.AddListener(()=>{
        GameManager.Instance.Reset();
        inGameSound.Stop();
        shopSound.Play();
        shop.SetActive(true);
        inGame.SetActive(false);
        });
    }

    private void Update()
    {
        if (EnemyManager.Instance.stageClear)
        {
            stageCanves.gameObject.SetActive(true);
            DOTween.To(() => stageCanves.alpha, x => stageCanves.alpha = x, 1, 0.5f);
        }
        else
        {
            DOTween.To(() => stageCanves.alpha, x => stageCanves.alpha = x, 0, 0.5f);
            stageCanves.gameObject.SetActive(false);
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
