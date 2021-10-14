using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region �̱���
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
    //�������� ����

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
