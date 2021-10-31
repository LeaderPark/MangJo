using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region ?쎄???
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
    public float Rampart_MaxHp;
    public Slider Rampart_Hp_Ui;
    public Text Rampart_Hp_tex;

    public Text stageTex;

    public int coin;
    public Text stageState;

    public ParticleSystem coinEffect;
    public void Start()
    {
        Rampart_NowHp = Rampart_MaxHp;
        Rampart_Hp_Ui.value = Rampart_NowHp / Rampart_MaxHp;
        Rampart_Hp_tex.text = Rampart_NowHp.ToString();
    }
    public void IsDamage(int hitDps)
    {
        Rampart_NowHp -= hitDps;
        if(Rampart_NowHp <=0){
            //게임 오버
            EnemyManager.Instance.stageClear = true;
            stageState.text = "StageFail";
            stageState.color = Color.red;
        }
        Rampart_Hp_Ui.value = Rampart_NowHp / Rampart_MaxHp;
        Rampart_Hp_tex.text = Rampart_NowHp.ToString();
    }
    public void Reset(){
        float a =  Rampart_NowHp - Rampart_MaxHp;
        IsDamage((int)a);
        stageTex.text = (stage+1)+" 스테이지";
        stageState.text = "StageClear";
        stageState.color = Color.white;
        //리셋할것 추가
    }
    public void GetCoin(int getCoin){
        coin += getCoin;
        coinEffect.Play();
        
    }
}
