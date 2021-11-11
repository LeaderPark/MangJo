using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPenal : MonoBehaviour
{
    //가격 레벨 버튼
    public int pay;

    public int addPay;
    public int level;


    public int addStat;
    public Text levelTex;

    public Button buyBtn;

    public Text payTex;
    

    public ShopManager SM;

    public string Name;
    
    void Start()
    {

        if(GameManager.Instance.dic.ContainsKey("Coin")){

        SM =GameObject.Find("ShopManager").GetComponent<ShopManager>();
        levelTex.text = level.ToString() + "Level";
        payTex.text = pay.ToString() + "원";
        buyBtn.onClick.AddListener(()=>{
            if(GameManager.Instance.dic["Coin"] > pay){
                BuyItem();
            }
            else{
                StartCoroutine(SM.NoMoney());
            }
        });
        }
    }

    public void BuyItem(){
        GameManager.Instance.dic["Coin"] -= pay;
        level ++;
        levelTex.text = level.ToString() + "Level";
        pay += addPay;
        payTex.text = pay.ToString() + "원";
        GameManager.Instance.dic[Name] += addStat;
        float coin = GameManager.Instance.dic["Coin"];
        Debug.Log(coin);
        SM.nowMoney.text = coin.ToString()+ " 원";    
        
    }
}
