using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataTable");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("스테이지 " + data[i]["Stage"] + " 적 번호 : " + data[i]["Monster"] + " 몇 명? : " + data[i]["Count"]);
        }

    }
}
