using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public Button nextBtn;
    public Button BeforeBtn;
    public List<Button> menuBtn = new List<Button>();

    public int nowMain;
    void Start()
    {
        transform.localPosition = new Vector2(-350f,0);
        for (int i = 0; i < menuBtn.Count; i++)
        {
            menuBtn[i].enabled = false;

            menuBtn[i].gameObject.transform.DOScale(0.8f,0);

            menuBtn[i].gameObject.GetComponentsInChildren<Image>()[2].
            DOColor(new Color(0,0,0,0.65f),0);
        }
        BtnOn(nowMain);
        nextBtn.onClick.AddListener(()=>{
            if(nowMain+1 < menuBtn.Count){
                BtnOff(nowMain);
                nowMain++;
                BtnOn(nowMain);
                int a = -800*(nowMain);
                transform.DOLocalMoveX(-350+a,1);
            }
        });
        BeforeBtn.onClick.AddListener(()=>{
            if(nowMain > 0){
                BtnOff(nowMain);
                nowMain--;
                BtnOn(nowMain);
                int a = -800*(nowMain);
                transform.DOLocalMoveX(-350+a,1);
            }
        });
    }

    public void BtnOff(int num){
        
        menuBtn[num].enabled = false;

        menuBtn[num].gameObject.transform.DOScale(0.8f,1);

        menuBtn[num].gameObject.GetComponentsInChildren<Image>()[2].
        DOColor(new Color(0,0,0,0.65f),1);
    }

    public void BtnOn(int num){
        
        menuBtn[num].enabled = true;

        menuBtn[num].gameObject.transform.DOScale(1f,1);

        menuBtn[num].gameObject.GetComponentsInChildren<Image>()[2].
        DOColor(new Color(0,0,0,0f),1);
    }
}
