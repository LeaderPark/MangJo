using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region 씽글톤
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    #endregion

    public int stage;
    public float Rampart_NowHp;

    public bool stageFail;
    public Dictionary<string,float> dic = new Dictionary<string, float>(){
        {"Coin", 0},
        {"bullet_Damage",20},
        {"Rampart_MaxHp",100}
    };
    public void IsDamage(int hitDps)
    {
        Rampart_NowHp -= hitDps;
        if(Rampart_NowHp <=0){
            //게임 오버
            stageFail = false;
            InGameScript.Instance.stageState.text = "StageFail";
            InGameScript.Instance.stageState.color = Color.red;
            EnemyManager.Instance.spawnEnemys.RemoveRange(0,EnemyManager.Instance.spawnEnemys.Count); 
            EnemyManager.Instance.left_enemy =0;        
            EnemyManager.Instance.stageClear = true;
        }
        InGameScript.Instance.Rampart_Hp_Ui.value = Rampart_NowHp / dic["Rampart_MaxHp"];
        // InGameScript.Instance.coinTex.text = Rampart_NowHp.ToString();
    }
    public void Reset(){
        float a =  Rampart_NowHp - dic["Rampart_MaxHp"];
        IsDamage((int)a);
        InGameScript.Instance.stageTex.text = (GameManager.Instance.stage+1)+" 스테이지";
        InGameScript.Instance.stageState.text = "StageClear";
        InGameScript.Instance.stageState.color = Color.white;
        
        //리셋할것 추가
    }


}
