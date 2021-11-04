using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SkillSystem : MonoBehaviour
{
    [SerializeField]
    GameObject blockBox;

    [SerializeField]
    Transform[] blockPosition = new Transform[maxBlockCount];

    public List<GameObject> skillBlocks = new List<GameObject>();
    IEnumerator[] OnMoveBlock = new IEnumerator[maxBlockCount];

    const int maxBlockCount = 9;
    const int maxBlockChain = 3;
    const float blockSpeed = 50.0f;

    const float soldierUnitInitXPos = -20f;
    const float soldierUnitInitYPos = -2.35f;
    const float soldierUnitDistance = 2f;
    const float maxCameraXPos = 48.21f;

    //GameObject m_map;

    List<GameObject> soldierUnits = new List<GameObject>();
    List<GameObject> monsterUnits = new List<GameObject>();

    // [SerializeField]
    // StageSoldierInfo m_stageSoldierInfo;

    public float createSkillBlock = 1.5f;

    bool stageClear = false;
    bool gameOver = false;

    void Start() 
    {
        StartCoroutine(CreateBlock());
    }

    void Update() 
    {
        
        for(int index = 0; index < skillBlocks.Count; index++)
        {
            if(skillBlocks[index].GetComponent<SkillBlock>().GetBlockIndex() != index)
            {
                OnMoveBlock[index] = MoveBlock(index);
                StartCoroutine(OnMoveBlock[index]);
            }
        }

        if (stageClear || gameOver) return;

        if (CheckStageClear())
        {
            stageClear = true;
            //StageManager.Instance.SetClear(true);

            StopCoroutine(CreateBlock());
            //StartCoroutine(StageClear());
        }

        if(CheckGameOver())
        {
            gameOver = true;

            StopCoroutine(CreateBlock());
            //StartCoroutine(GameOver());
        }
    }

    IEnumerator CreateBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(createSkillBlock);
            if(skillBlocks.Count < maxBlockCount)
            {
                int random = UnityEngine.Random.Range(0, 3);
                GameObject block = Instantiate(Resources.Load("Block/BlockUI") as GameObject, blockBox.transform);
                block.transform.position = blockPosition[maxBlockCount - 1].position;
                block.GetComponent<SkillBlock>().touchDelegate = UseBlock;
                skillBlocks.Add(block);

                //string thumbnailPath = soldierUnits[random].GetComponent<SoldierUnit>().GetSkillThumbnail();
                block.GetComponent<SkillBlock>().InitializeSkillBlock(maxBlockCount, (BlockColor)random, true, "Skill/Call of the Holy Sword/Call of the Holy Sword_sprite");
            }      
        }
    }

    void UseBlock(int index)
    {
        if (skillBlocks[index].transform.position.x != blockPosition[index].position.x) return;

        List<int> linkedBlockIndex = GetLinkedBlocksIndex(index);
        if(!gameOver && !stageClear)
        {
            //soldierUnits[(int)skillBlocks[index].GetComponent<SkillBlock>().GetBlockColor()].GetComponent<SoldierUnit>().AddSkillLink(linkedBlockIndex.Count);
        }

        int minIndex = maxBlockCount;
        foreach(int blockIndex in linkedBlockIndex)
        {
            minIndex = minIndex > blockIndex ? blockIndex : minIndex;
            skillBlocks[blockIndex].GetComponent<SkillBlock>().CreateParticle();
            Destroy(skillBlocks[blockIndex]);
        }

        for(int i = 0; i < maxBlockCount; i++)
        {
            if(OnMoveBlock[i] != null) StopCoroutine(OnMoveBlock[i]);
        }
        
        skillBlocks.RemoveRange(minIndex, linkedBlockIndex.Count);
    }

    IEnumerator MoveBlock(int blockIndex)
    {
        skillBlocks[blockIndex].GetComponent<SkillBlock>().SetBlockIndex(blockIndex);

        while (skillBlocks[blockIndex].transform.position.x != blockPosition[blockIndex].position.x)
        {
            yield return null;

            skillBlocks[blockIndex].transform.position = Vector3.MoveTowards(skillBlocks[blockIndex].transform.position,
                blockPosition[blockIndex].position, blockSpeed);
        }

        if (!skillBlocks[blockIndex].GetComponent<SkillBlock>().IsPrevBlockLinked() && CanBlockLink(blockIndex))
        {
            skillBlocks[blockIndex].GetComponent<SkillBlock>().PrevBlockLink();
            skillBlocks[blockIndex - 1].GetComponent<SkillBlock>().NextBlockLink();

            if(GetLinkedBlocksIndex(blockIndex).Count == maxBlockChain)
            {
                foreach(int index in GetLinkedBlocksIndex(blockIndex))
                {
                    skillBlocks[index].GetComponent<SkillBlock>().AnimationPlay();
                }
            }
        }
    }

    bool CanBlockLink(int blockIndex)
    {
        if (blockIndex == 0) return false;

        int linkCount = 0;        
        for(int index = 0; index < blockIndex; index++)
        {
            if (skillBlocks[index].GetComponent<SkillBlock>().GetBlockColor()
                == skillBlocks[blockIndex].GetComponent<SkillBlock>().GetBlockColor())
            {
                linkCount++;
                linkCount %= maxBlockChain;
            }
            else
            {
                linkCount = 0;
            }
        }

        return linkCount > 0;
    }

    List<int> GetLinkedBlocksIndex(int index)
    {
        List<int> linkedBlockIndex = new List<int>();

        int prevIndex = index;
        while (skillBlocks[prevIndex].GetComponent<SkillBlock>().IsPrevBlockLinked())
        {
            prevIndex--;
            linkedBlockIndex.Add(prevIndex);
        }

        linkedBlockIndex.Add(index);

        int nextIndex = index;
        while(skillBlocks[nextIndex].GetComponent<SkillBlock>().IsNextBlockLinked())
        {
            nextIndex++;
            linkedBlockIndex.Add(nextIndex);
        }

        return linkedBlockIndex;
    }

    bool CheckGameOver()
    {
        bool isGameOver = true;
        // for (int index = 0; index < m_soldierUnits.Count; index++)
        // {
        //     if (!m_soldierUnits[index].GetComponent<UnitBase>().IsDie())
        //     {
        //         isGameOver = false;
        //         break;
        //     }
        // }

        return isGameOver;
    }

    // IEnumerator GameOver()
    // {
    //     GameObject stageClearUI = Instantiate(Resources.Load("UI/GameOver") as GameObject);

    //     yield return new WaitForSeconds(4.25f);

    //     SceneManager.LoadScene("Lobby");
    //     UIManager.Instance.RemoveOneUI();
    // }

    bool CheckStageClear()
    {
        bool isStageClear = true;
        // for (int index = 0; index < m_monsterUnits.Count; index++)
        // {
        //     if (!m_monsterUnits[index].GetComponent<UnitBase>().IsDie())
        //     {
        //         isStageClear = false;
        //         break;
        //     }
        // }

        return isStageClear;
    }

    // IEnumerator StageClear()
    // {
    //     float goalPosition = Camera.main.transform.position.x - 3.23f;

    //     for (int index = 0; index < m_soldierUnits.Count; index++)
    //     {
    //         m_soldierUnits[index].GetComponent<SoldierUnit>().SetGoalPoint(goalPosition + (index * 3.23f));
    //     }

    //     bool isGoal = false;
    //     while (!isGoal)
    //     {
    //         yield return null;

    //         isGoal = true;
    //         for (int index = 0; index < m_soldierUnits.Count; index++)
    //         {
    //             if (!m_soldierUnits[index].GetComponent<SoldierUnit>().IsGoal())
    //             {
    //                 isGoal = false;
    //                 break;
    //             }
    //         }
    //     }

    //     GameObject stageClearUI = Instantiate(Resources.Load("UI/StageClear") as GameObject);

    //     yield return new WaitForSeconds(4.25f);

    //     SceneManager.LoadScene("Result");
    //     UIManager.Instance.RemoveOneUI();
    // }

    void OnFinishedStage()
    {
        StopCoroutine(CreateBlock());
    }
}