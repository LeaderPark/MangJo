using System.Collections;
using System.Collections.Generic;
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
    private float Rampart_NowHp;
    public float Rampart_MaxHp;
    public Slider Rampart_Hp_Ui;
    public Text Rampart_Hp_tex;
    public void Start()
    {
        Rampart_NowHp = Rampart_MaxHp;
        Rampart_Hp_Ui.value = Rampart_NowHp / Rampart_MaxHp;
        Rampart_Hp_tex.text = Rampart_NowHp.ToString();
    }
    public void IsDamage(int hitDps)
    {
        Rampart_NowHp -= hitDps;
        Rampart_Hp_Ui.value = Rampart_NowHp / Rampart_MaxHp;
        Rampart_Hp_tex.text = Rampart_NowHp.ToString();
    }
}
