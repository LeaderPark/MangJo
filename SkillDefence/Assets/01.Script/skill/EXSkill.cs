using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXSkill : MonoBehaviour
{


    public void Skill1()
    {
        foreach (var enemy in EnemyManager.Instance.spawnEnemys)
        {
            enemy.GetComponent<EnemyControl>().enemy_NowHp -= 10f;
        }
    }
        
    public void Skill2()
    {
        FindObjectOfType<PlayerAtk>().atkSpeed += 1f;
    }

    public void Skill3()
    {
        if(GameManager.Instance.Rampart_NowHp <= 80f)
        GameManager.Instance.Rampart_NowHp += 20f;
    }

    public void Skill4()
    {
        foreach (var enemy in EnemyManager.Instance.spawnEnemys)
        {
            enemy.GetComponent<EnemyControl>().enemySpeed -= 0.5f;
        }
    }

}
