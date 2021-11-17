using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : Singleton<ShopManager>
{

    public Button exitShop;

    public Text nowMoney;
    public CanvasGroup moneyCanvas;

    public GameObject shop;

    public GameObject inGame;

    public AudioSource inGameSound;

    public AudioSource shopSound;
    
    private void Start() {
        exitShop.onClick.AddListener(()=>{
            ExitShop();
        });
    }

    private void Update() {
        if(EnemyManager.Instance.stageClear){
            float coin = GameManager.Instance.dic["Coin"];
            nowMoney.text = coin.ToString()+ " 원";    
        }    
    }
    public void ExitShop(){
        inGameSound.Play();
        shopSound.Stop();
        shop.SetActive(false);
        inGame.SetActive(true);
    }

    public IEnumerator NoMoney(){
        DOTween.To(() => moneyCanvas.alpha, x=> moneyCanvas.alpha = x,1,0.1f);
        yield return new WaitForSeconds(0.5f);
        DOTween.To(() => moneyCanvas.alpha, x=> moneyCanvas.alpha = x,0,0.1f);

    }
}
