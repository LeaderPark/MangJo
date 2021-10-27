using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlockColor
{
    Orange,
    Blue,
    Green
}

public class SkillBlock : MonoBehaviour
{
    private bool active;

    private int blockIndex;

    private BlockColor color;

    private bool prevLink = false;

    private bool nextLink = false;

    [SerializeField]
    Image thumbnail;

    [SerializeField]
    Image edge;

    [SerializeField]
    Sprite[] edgeSprite;

    [SerializeField]
    Image link;

    [SerializeField]
    Sprite[] linkSprite;

    [SerializeField]
    Image glowBlock;

    [SerializeField]
    Image glowEdge;

    Animator anim;

    public delegate void blockTouchDelegate(int index);

    public blockTouchDelegate touchDelegate;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void InitializeSkillBlock(int index, BlockColor color, bool activeValue, string thumbnailPath)
    {
        blockIndex = index;
        this.color = color;
        active = activeValue;
        thumbnail.sprite = Resources.Load<Sprite>(thumbnailPath);
        edge.sprite = edgeSprite[(int)color];
        link.sprite = linkSprite[(int)color];
    }

    public void Start()
    {
        thumbnail.material = new Material(thumbnail.material);

        glowBlock.material = new Material(glowBlock.material);
        glowBlock.material.SetFloat("_Intensity", 1.56f);

        glowEdge.material = new Material(glowEdge.material);
        glowEdge.material.SetFloat("_Intensity", 1.56f);
    }

    public void NextBlockLink()
    {
        nextLink = true;
    }

    public bool IsNextBlockLinked()
    {
        return nextLink;
    }

    public BlockColor GetBlockColor()
    {
        return color;
    }

    public int GetBlockIndex()
    {
        return blockIndex;
    }

    public void SetBlockIndex(int index)
    {
        blockIndex = index;
    }

    public void PrevBlockLink()
    {
        prevLink = true;
        link.gameObject.SetActive(true);
    }

    public bool IsPrevBlockLinked()
    {
        return prevLink;
    }

    public void OnTouchBlock()
    {
        if (touchDelegate != null) touchDelegate(blockIndex);
    }

    public void AnimationPlay()
    {
        anim.SetBool("isLinked", true);
    }

    public void CreateParticle()
    {
        GameObject touchParticle = Instantiate(Resources.Load("Block/BlockTouchEffect") as GameObject, transform.parent);
        touchParticle.transform.position = transform.position;
        touchParticle.GetComponent<BlockTouchParticle>().InitializeParticle(color, active);
    }

    public void DeactivateBlock()
    {
        active = false;
        thumbnail.material.SetFloat("_EffectAmount", 1);
    }
}
