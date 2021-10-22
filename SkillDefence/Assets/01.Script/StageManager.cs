using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //癲ル슣????癲?????읐????嶺? ?嶺뚮Ĳ?됮????낆뒩?????縕??GameManager.Instance.stage)
    //StartCoroutine(StageStart(癲ル슢??猿껎맪筌뚮갭??? ???쒓낫????,??????濡ろ뜐??????щ빘???됰씭肄?);
    //????읐??? ?????癲ル슢???낆릇???(EnemyManager.Instance.enemy_amount;) 癲ル슢??猿껎맪筌뚮갭??? ???쒓낫????(???濡ろ뜐???????щ빘???됰씭肄????????嚥▲꺂痢?????? ??縕??
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
                    //???댟??? 1?? ????먩쾬?0?뺢퀡??琉룹쾸? 3嶺뚮씭???0.8?貫????띠룄?①댆??怨쀬Ŧ
                    Debug.Log("1?ㅽ뀒?댁?");
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
        //amount癲ル슢???移?enemy?????ル늅???????獄쏅똻??
        for (int i = 0; i < amount; i++)
        {
            GameObject e = Instantiate(enemy, spawnEnemy.transform);
            e.GetComponent<EnemyControl>().enemy_bar = Instantiate(EnemyManager.Instance.enemyHp, enemyCanvas.transform);
            //???ㅼ굣獄??域밸Ŧ遊얕짆?嶺뚮ㅎ???????
            EnemyManager.Instance.AddEnemyList(e);
            yield return new WaitForSeconds(sec);
        }
    }
}
