using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    public string unitIdentity;  
    public int indetityNum;
    public Text myText;

    private void Start() {
        myText = GetComponent<Text>(); 
    }

    public void setUnitText()
    {
        myText.text = unitIdentity;
    }

    public void setUnitIdentitiy(int index)
    {
        unitIdentity = index.ToString();
    }
}
