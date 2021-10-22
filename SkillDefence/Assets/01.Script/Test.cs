using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<Dictionary<string, object>> data_Dialog = CSVReader.Read("DataTable");
    void Start()
    {
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            Debug.Log(data_Dialog[i]["Content"].ToString());
        }
    }

    void Update()
    {
        
    }
}
