using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MapPointText : MonoBehaviour
{
    public string content;
    
    public Text m_text;

    // Update is called once per frame
    void Update()
    {
        m_text.text = content;
    }
}
