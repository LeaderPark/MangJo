using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MapMove : MonoBehaviour
{
    public Transform m_Camera;
    public Button backMove;
    public Button nextMove;

    void Start() 
    {
        backMove.onClick.AddListener(() => backMap());
        nextMove.onClick.AddListener(() => nextMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextMap()
    {
        m_Camera.DOMoveX(17.8f, 0.5f);
    }

    void backMap()
    {
        m_Camera.DOMoveX(0, 0.5f);
    }
}
