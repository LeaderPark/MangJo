using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    Text[] unitText; 
    GameObject UnitSelecPanel;
    GameObject buttons;


    private void Start() {
        for (int i = 0; i < UnitSystem.Instance.myunitList.Count; i++)
        {
            GameObject e = Instantiate(buttons, transform.position, Quaternion.identity, UnitSelecPanel.transform);
            e.GetComponent<UnitBase>().setUnitIdentitiy(i);
            e.GetComponent<UnitBase>().setUnitText();
        }
    }

    public void SelectUnit(string unit)
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
