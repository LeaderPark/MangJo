using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //嶺뚯솘???嶺????댟????筌? ?筌먦끉逾???낅슣?????貫??GameManager.Instance.stage)
    //StartCoroutine(StageStart(嶺뚮ㅏ?껃퐲琉밸뎨?? ??瑜곴텕???,??????롪퍓?????듬땹??釉띾콦));
    //???댟??? ?????嶺뚮ㄳ?낅츩???(EnemyManager.Instance.enemy_amount;) 嶺뚮ㅏ?껃퐲琉밸뎨?? ??瑜곴텕???(???롪퍓??????듬땹??釉띾콦????????濡ル츎 ????? ??貫??
    public Button nextStageBtn;
    public Canvas enemyCanvas;
    public GameObject spawnEnemy;
    private void Start()
    {
        nextStageBtn.onClick.AddListener(() => 
        {

            EnemyManager.Instance.stageClear = false;
            switch (GameManager.Instance.stage)
            {
                case 0:
                    //??쎈??? 1?? ?癒?섐沃?0甕곕뜆?뤷첎? 3筌띾뜄??0.8?λ뜆??揶쏄쑨爰??곗쨮
                    Debug.Log("1스테이지");
                    StartCoroutine(StageStart(3, EnemyManager.Instance.enemy_Spawn[0], 0.8f));
                    StartCoroutine(StageStart(5, EnemyManager.Instance.enemy_Spawn[1], 1.5f));
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:
                    
                    break;
                case 8:
                    
                    break;
                case 9:
                    
                    break;
                case 10:
                    
                    break;
                case 11:
                    
                    break;
                case 12:
                    
                    break;
                case 13:
                    
                    break;
                case 14:
                    
                    break;
                case 15:
                    
                    break;
                case 16:
                    
                    break;
                case 17:
                    
                    break;
                case 18:
                    
                    break;
                case 19:
                    
                    break;
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
        //amount嶺뚮씭??칰?enemy????ル봾堉??????諛댁뎽
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy, spawnEnemy.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp, enemyCanvas.transform);
            //??⑤챷諭??洹먮봾裕?筌뤾쑬??????
            EnemyManager.Instance.AddEnemyList(e);
            yield return new WaitForSeconds(sec);
        }
    }
}
