using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    Text[] unitText; 
    Button[] buttons;

    private void Start() {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<UnitBase>().indetityNum = i;
        }
    }

    void SelectUnit(string unit)
    {
        int count = 0;
        if(count == 0)
        {
            unitText[0].text = unit;
            count++;            
        }
        else if(count == 1)
        {
            unitText[1].text = unit;
            count++;  
        }
            
        else if(count == 2)
        {
            unitText[1].text = unit;
            count = 0;
        } 
    }
}
