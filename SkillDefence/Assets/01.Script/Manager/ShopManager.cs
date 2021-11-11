using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : MonoBehaviour
{

    public Button exitShop;

    public Text nowMoney;
    public CanvasGroup moneyCanvas;

    
    private void Start() {
        float coin = GameManager.Instance.dic["Coin"];
        Debug.Log(coin);
        nowMoney.text = coin.ToString()+ " 원";    

        exitShop.onClick.AddListener(()=>{
            ExitShop();
        });
    }

    public void ExitShop(){
        SceneManager.LoadScene("Taehyen");
    }

    public IEnumerator NoMoney(){
        DOTween.To(() => moneyCanvas.alpha, x=> moneyCanvas.alpha = x,1,0.1f);
        yield return new WaitForSeconds(0.5f);
        DOTween.To(() => moneyCanvas.alpha, x=> moneyCanvas.alpha = x,0,0.1f);

    }
}
