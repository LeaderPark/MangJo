using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpanw : MonoBehaviour
{
    public Button stageBtn;
    public GameObject Mgr;
    public void Start()
    {

        stageBtn.onClick.AddListener(() =>
        {
            StartCoroutine(StageStart(GameManager.Instance.stage));
        });
    }

    IEnumerator StageStart(int stageCount)
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(EnemyManager.Instance.enemy_Spawn[0],gameObject.transform);
            yield return new WaitForSeconds(0.5f);
        }
        GameManager.Instance.stage++;
    }

}
