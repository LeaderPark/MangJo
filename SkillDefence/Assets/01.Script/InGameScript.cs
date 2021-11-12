using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScript : Singleton<InGameScript>
{
    public Slider Rampart_Hp_Ui;
    public Text Rampart_Hp_tex;

    public Text stageTex;

    public Text coinTex;
    public Text stageState;
    // Start is called before the first frame update
    void Start()
    {

        if(GameManager.Instance.dic.ContainsKey("Coin")){
            
        GameManager.Instance.Rampart_NowHp = GameManager.Instance.dic["Rampart_MaxHp"];
        Rampart_Hp_Ui.value = GameManager.Instance.Rampart_NowHp / GameManager.Instance.dic["Rampart_MaxHp"];
        Rampart_Hp_tex.text = GameManager.Instance.Rampart_NowHp.ToString();
        coinTex.text = GameManager.Instance.dic["Coin"].ToString();
        }

    }
    private void Update() {
        Rampart_Hp_Ui.value = GameManager.Instance.Rampart_NowHp / GameManager.Instance.dic["Rampart_MaxHp"];
        Rampart_Hp_tex.text =  GameManager.Instance.Rampart_NowHp.ToString();
    }

}
