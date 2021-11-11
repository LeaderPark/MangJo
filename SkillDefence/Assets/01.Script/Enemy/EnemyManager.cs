using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    #region 싱글톤
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
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
    public List<GameObject> enemy_Spawn = new List<GameObject>();
    public List<int> enemy_amount = new List<int>();

    public Slider enemyHp;

    public int left_enemy;

    public List<GameObject> spawnEnemys = new List<GameObject>();

    public bool stageClear = true;

    public ParticleSystem coinEffect;


    public void AddEnemyList(GameObject addEnemy)
    {
        left_enemy++;
        spawnEnemys.Add(addEnemy);
    }

    public void RemoveEnemyList(GameObject removeEnemy)
    {
        left_enemy--;
        spawnEnemys.Remove(removeEnemy);
        if (left_enemy <= 0)
        {
            GameManager.Instance.stage++;
            stageClear = true;
            GameManager.Instance.Reset();
            GetCoin(200);
        }
    }


    public void GetCoin(int getCoin){

        if(GameManager.Instance.dic.ContainsKey("Coin")){
            GameManager.Instance.dic["Coin"] += getCoin;
            Debug.Log( GameManager.Instance.dic["Coin"]);
        }
        

        coinEffect.Play();
        InGameScript.Instance.coinTex.text = GameManager.Instance.dic["Coin"].ToString();
        

    }

    

}