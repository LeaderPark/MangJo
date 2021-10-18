using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public GameObject[] skillPrefab; 
    public GameObject skillParent;
    public Transform spawnPoint;

    public List<Skill> skillList = new List<Skill>();

    [Header("Enemy Create Info")]
    public int maxEnemy = 5;
    private int enemyCount = 0;
    private bool isGameOver = false;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("다수의 게임매니저가 실행중");
        }
        instance = this;

        for (int i = 0; i < 20; i++)
        {
            GameObject e = CreateSkill();
            e.SetActive(false);
            Skill sk = e.GetComponent<Skill>();
            skillList.Add(sk);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnSkill());
    }

    private GameObject CreateSkill()
    {
        int rd = UnityEngine.Random.Range(0,skillPrefab.Length);
        return Instantiate(skillPrefab[rd],
            transform.position,
            Quaternion.identity,
            transform
            );
    }

    IEnumerator SpawnSkill()
    {
        while(!isGameOver)
        {
            if(enemyCount < maxEnemy)
            {
                Skill sk = skillList.Find(x => !x.gameObject.activeSelf);

                if(sk == null)
                {
                    GameObject e = CreateSkill();
                    sk = e.GetComponent<Skill>();
                    skillList.Add(sk);
                }

                enemyCount++;
                sk.transform.position = spawnPoint.transform.position;
                sk.transform.SetParent(spawnPoint);
                sk.gameObject.SetActive(true);
                sk.Move();

                // Action handler = null;
                // handler = () =>
                // {
                //     enemyCount--;
                //     sk.OnDeath -= handler;
                // };

                // sk.OnDeath += handler;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}