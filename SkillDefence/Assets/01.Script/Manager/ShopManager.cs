using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : MonoBehaviour
{
    public Text hp_Level_Tex;
    public Text Hp_Count;
    public int coin_Hp;
    public int hp_level;


    public Text skill_Level_Tex;
    public Text skill_Count;
    public int coin_Skill;

    public int skill_level;

    public CanvasGroup moneyCanvas;

    public void start()
    {
        //처음 값 초기화 해야함
        
    }
    public void Hp_LevelUp(){
        if(GameManager.Instance.coin >= coin_Hp){
            GameManager.Instance.coin -= coin_Hp;
            GameManager.Instance.Rampart_MaxHp += 100;
            coin_Hp += 100;
            hp_level++;
            hp_Level_Tex.text = hp_level.ToString() + " Level";
            Hp_Count.text = coin_Hp.ToString()+ "원";
        }
        else{
            StartCoroutine(NoMoney());
        }
    }

    public void Skill_LevelUp(){
        if(GameManager.Instance.coin >= coin_Skill){
            GameManager.Instance.coin -= coin_Skill;
            GameManager.Instance.bullet_Damage += 10;
            coin_Skill += 200;
            skill_level++;
            skill_Count.text = skill_level.ToString() +" Level";
            skill_Count.text = coin_Skill.ToString() + "원";
        }
        else{
            StartCoroutine(NoMoney());
        }
    }

    public void ExitShop(){
        SceneManager.LoadScene(0);
    }

    public IEnumerator NoMoney(){
        moneyCanvas.DOFade(1,0.1f);
        yield return new WaitForSeconds(0.5f);
        moneyCanvas.DOFade(0,0.1f);

    }
}
